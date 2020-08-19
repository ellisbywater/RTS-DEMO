using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    public static Vector3[] GetUnitGroupDestinations(Vector3 moveToPos, int numUnits, float unitGap)
    {
        // vector3 array for final destinations
        Vector3[] destinations = new Vector3[numUnits];

        int rows = Mathf.RoundToInt(Mathf.Sqrt(numUnits));
        int cols = Mathf.CeilToInt((float) numUnits / (float) rows);

        int curRow = 0, curCol = 0;

        float width = ((float) rows - 1) * unitGap;
        float length = ((float) cols - 1) * unitGap;

        for (int x = 0; x < numUnits; x++)
        {
            destinations[x] = moveToPos + (new Vector3(curRow, 0, curCol) * unitGap) - new Vector3(length / 2, 0, width / 2);
            curCol++;

            if (curCol == rows)
            {
                curCol = 0;
                curRow++;
            }
        }
        
        return destinations;
    }

}
