using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [Header("Units")]
   public List<Unit> units = new List<Unit>();

      // Is this my unit
   public bool isMyUnit(Unit unit)
   {
      return units.Contains(unit);
   }
}
