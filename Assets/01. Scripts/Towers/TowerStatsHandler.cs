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
    public float ShootDamage(int index) => tower.stats.typeStats[index].statData.damage *
        Mathf.Pow(tower.stats.typeStats[index].upgradeCount, tower.stats.typeStats[index].statData.upgradeFactor);

    public float UpgradePrice(int index) => tower.stats.typeStats[index].statData.upgradeCost *
        Mathf.Pow(2, tower.stats.typeStats[index].upgradeCount);

    //변경 필요, 업그레이드를 할 때, 이 메서드가 호출되어 가격이 증가해야함
    //public float TotalSellPrice => 
    
    //메서드 필요 => tower.stats.typeStats[index].currentDamage 를 변경해줄 방법...
}
