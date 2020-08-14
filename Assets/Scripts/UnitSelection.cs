using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public LayerMask UnitLayerMask;
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
        }
    }

    void TrySelect(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, UnitLayerMask))
        {
            Unit unit = hit.collider.GetComponent<Unit>();
        }
    }

    void ToggleSelectionVisual(bool selected)
    {
        foreach (Unit unit in selectedUnits)
        {
            unit.ToggleSelectionVisual(selected);
        }
    }
}
