using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TowerDatabase", menuName ="Towers/PrefabDatabase")]
public class TowerPrefabListSO : ScriptableObject
{
    [SerializeField]
    private List<Tower> towerList;

    public List<Tower> TowerList { get { return towerList; } }

    public int ReturnTowerIndex(Tower tower)
    {
        for(int i = 0; i < towerList.Count; i++)
        {
            if (towerList[i] == tower)
            {
                return i;
            }
        }

        return -1;
    }
}
