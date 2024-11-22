using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats
{
    private readonly int normalTowerListCount = 6;

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

        if(listData.AttackLists.Count == normalTowerListCount)
        {
            typeStats[normalTowerListCount - 1].isActive = true;
        }
        else
        {
            typeStats[0].isActive = true;
        }
    }

    /// <summary>
    /// 타입을 받아서 해당 타입의 스텟정보를 모두 반환함, null 이 반환되면 오류(타워에 해당 스텟이 없음)
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public AttackTypeStat ReturnStatByType(AttributeType type)
    {
        for(int i = 0; i < typeStats.Count; i++)
        {
            if (typeStats[i].statData.type == type)
            {
                return typeStats[i];
            }
        }

        return null;
    }
}
