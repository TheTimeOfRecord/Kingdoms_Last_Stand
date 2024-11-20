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
    /// ���� Ÿ�� ����Ʈ���� ������ ��������, Ÿ�� ������ tower.stats.typeStats[index].statData.type ���� �����;���
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float ShootDamage(int index) => tower.stats.typeStats[index].statData.damage *
        Mathf.Pow(tower.stats.typeStats[index].upgradeCount, tower.stats.typeStats[index].statData.upgradeFactor);

    public float UpgradePrice(int index) => tower.stats.typeStats[index].statData.upgradeCost *
        Mathf.Pow(2, tower.stats.typeStats[index].upgradeCount);

    //���� �ʿ�, ���׷��̵带 �� ��, �� �޼��尡 ȣ��Ǿ� ������ �����ؾ���
    //public float TotalSellPrice => 
    
    //�޼��� �ʿ� => tower.stats.typeStats[index].currentDamage �� �������� ���...
}
