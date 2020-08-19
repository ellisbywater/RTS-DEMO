using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public LayerMask UnitLayerMask;

    public RectTransform selectionBox;
    private Vector2 startPos;
    
    private List<Unit> selectedUnits = new List<Unit>();
    
    // components
    private Camera cam;
    private Player _player;

    private void Awake()
    {
        // get components
        cam = Camera.main;
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        // mouse down
        if (Input.GetMouseButtonDown(0))
        {
            ToggleSelectionVisual(false);
            selectedUnits = new List<Unit>();
            TrySelect(Input.mousePosition);
            startPos = Input.mousePosition;
        }
        
        // mouse up
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseSelectionBox();
        }
        // mouse button held down
        if (Input.GetMouseButton(0))
        {
            UpdateSelectionBox(Input.mousePosition);
        }
    }

    void TrySelect(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, UnitLayerMask))
        {
            Unit unit = hit.collider.GetComponent<Unit>();

            if (_player.isMyUnit(unit))
            {
                selectedUnits.Add(unit);
                unit.ToggleSelectionVisual(true);
            }
                
        }
    }

    void ToggleSelectionVisual(bool selected)
    {
        foreach (Unit unit in selectedUnits)
        {
            unit.ToggleSelectionVisual(selected);
        }
    }
    
    // called when we are creating our selection box
    void UpdateSelectionBox(Vector2 currentMousePosition)
    {
        if(!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);

        float width = currentMousePosition.x - startPos.x;
        float height = currentMousePosition.y - startPos.y;
        
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = startPos + new Vector2(width / 2, height / 2);
    }

    // called when we release selection box
    void ReleaseSelectionBox()
    {
        selectionBox.gameObject.SetActive(false);
        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        foreach (Unit unit in _player.units)
        {
            Vector3 screenPos = cam.WorldToScreenPoint(unit.transform.position);
            if (screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
            {
                selectedUnits.Add(unit);
                unit.ToggleSelectionVisual(true);
            }
        }
    }
    
    // returns whether or not we are selecting a unit or units
    public bool HasUnitSelected()
    {
        return selectedUnits.Count > 0 ? true : false;
    }

    public Unit[] GetSelectedUnits()
    {
        return selectedUnits.ToArray();
    }
}
