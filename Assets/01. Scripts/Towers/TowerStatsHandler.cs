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

    /// <summary>
    /// 공격 타입 리스트에서 데미지 가져오기, 타입 정보는 tower.stats.typeStats[index].statData.type 으로 가져와야함
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float ShootDamage(AttributeType type)
    {
        if (tower.typeListData.AttackLists.Count != 6)
        {
            return tower.stats.typeStats[0].statData.damage * Mathf.Pow(tower.stats.typeStats[0].upgradeCount, tower.stats.typeStats[0].statData.upgradeFactor);
        }
        else
        {
            int index = (int)type;
            float damage = tower.stats.typeStats[index].statData.damage * Mathf.Pow(tower.stats.typeStats[index].upgradeCount, tower.stats.typeStats[index].statData.upgradeFactor);
            return damage;
        }
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
