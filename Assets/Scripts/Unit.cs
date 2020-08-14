using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   [Header("Components")]
   public GameObject selectionVisual;
   public void ToggleSelectionVisual(bool selected)
   {
      selectionVisual.SetActive(selected);
   }
}
