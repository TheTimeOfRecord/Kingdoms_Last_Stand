using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats
{
    //포탑이 가진 공격속성
    public List<AttackTypeStat> typeStats = new List<AttackTypeStat>();

    //포탑 사거리, 공격속도
    public float currentRange;
    public float currentRate;

    /// <summary>
    /// 포탑 기본 사거리, 공격속도 지정 메서드
    /// </summary>
    /// <param name="range"></param>
    /// <param name="rate"></param>
    public void InitTowerData(float range, float rate)
    {
        currentRange = range;
        currentRate = rate;
    }

    public void InitAttackStats(AttackTypeStatListSO listData)
    {
        foreach(var statSO in listData.AttackLists)
        {
            typeStats.Add(new AttackTypeStat(statSO));
        }
    }
}
