using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTemp
{
    public int[] ownTowerCounts;

    public InventoryTemp()
    {
        //ownTowerCounts = new int[DataManager.Instance.towerPrefabDatabase.TowerList.Count];
        //Array.Fill(ownTowerCounts, 0);
    }

    public void GetTower(Tower tower)
    {
        int index = DataManager.Instance.towerPrefabDatabase.ReturnTowerIndex(tower);

        if(index >= 0)
        {
            ownTowerCounts[index]++;
        }
    }

    public Tower SpendTower(int index)
    {
        if (index < 0 || index >= ownTowerCounts.Length) return null;
        if (ownTowerCounts[index] <= 0) return null;
        ownTowerCounts[index]--;
        return DataManager.Instance.towerPrefabDatabase.TowerList[index];
    }
}
