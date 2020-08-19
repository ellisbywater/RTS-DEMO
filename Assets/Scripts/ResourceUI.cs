using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
  public GameObject popupPanel;
  public TextMeshProUGUI resourceQuantityText;
  public ResourceSource resource;

  void OnMouseEnter()
  {
    popupPanel.SetActive(true);
  }

  private void OnMouseExit()
  {
    popupPanel.SetActive(false);
  }

  public void OnResourceQuantityChange()
  {
    resourceQuantityText.text = resource.quantity.ToString();
  }
}
