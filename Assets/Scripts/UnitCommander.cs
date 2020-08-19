using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommander : MonoBehaviour
{
    public GameObject selectionMarkerPrefab;

    public LayerMask layerMask;
    
    
    // Components
    private UnitSelection _unitSelection;
    private Camera _camera;

    private void Awake()
    {
        _unitSelection = GetComponent<UnitSelection>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _unitSelection.HasUnitSelected())
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Unit[] selectedUnits = _unitSelection.GetSelectedUnits();
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    UnitsMoveToPosition(hit.point, selectedUnits);
                    CreateSelectionMarker(hit.point);
                }
            }
        }
    }

    void UnitsMoveToPosition(Vector3 movePosition, Unit[] units)
    {
        Vector3[] destinations = UnitMover.GetUnitGroupDestinations(movePosition, units.Length, 2); 
        for (int x = 0; x < units.Length; x++)
        {
            units[x].MoveToPosition(destinations[x]);
        }
    }

    // creates a new selection marker visual
    void CreateSelectionMarker(Vector3 pos)
    {
        Instantiate(selectionMarkerPrefab, new Vector3(pos.x, 0.1f, pos.z), Quaternion.identity);
    }
}
