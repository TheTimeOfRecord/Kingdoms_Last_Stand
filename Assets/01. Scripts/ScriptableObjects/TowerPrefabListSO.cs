using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TowerDatabase", menuName ="Towers/PrefabDatabase")]
public class TowerPrefabListSO : ScriptableObject
{
    [SerializeField]
    private List<Tower> towerList;

    public List<Tower> TowerList { get { return towerList; } }
}
