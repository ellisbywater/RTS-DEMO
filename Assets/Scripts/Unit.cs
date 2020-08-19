using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
   [Header("Components")]
   public GameObject selectionVisual;

   private NavMeshAgent _navMeshAgent;

   private void Awake()
   {
      _navMeshAgent = GetComponent<NavMeshAgent>();
   }

   public void MoveToPosition(Vector3 pos)
   {
      _navMeshAgent.isStopped = false;
      _navMeshAgent.SetDestination(pos);
   }

   public void ToggleSelectionVisual(bool selected)
   {
      selectionVisual.SetActive(selected);
   }
}
