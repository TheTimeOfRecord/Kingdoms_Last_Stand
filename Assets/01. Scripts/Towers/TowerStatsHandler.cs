using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatsHandler
{
    private Tower tower;

    public float SellPrice { get; private set; }

    public TowerStatsHandler(Tower tower)
    {
        this.tower = tower;
    }

    public float UpgradePrice(AttributeType type)
    {
        if (tower.typeListData.AttackLists.Count != 6) return 0;

        int index = (int)type;
        float price = tower.stats.typeStats[index].statData.upgradeCost * Mathf.Pow(2, tower.stats.typeStats[index].upgradeCount);
        return price;
    }

    public void AddUpgradePrice(AttributeType type)
    {
        SellPrice += UpgradePrice(type);
    }

    public void ActiveTowerTypeAttack(AttributeType type)
    {
        int index = (int)type;

        if (tower.stats.typeStats[index].isActive == true) return;

        tower.stats.typeStats[index].isActive = true;
    }
}
