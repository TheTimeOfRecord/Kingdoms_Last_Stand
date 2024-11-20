using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackTypeStatList", menuName = "ScriptableObject/AttackTypeStatList", order = 1)]
public class AttackTypeStatListSO : ScriptableObject
{
   public List<AttackTypeStatSO> AttackLists = new List<AttackTypeStatSO>();
}