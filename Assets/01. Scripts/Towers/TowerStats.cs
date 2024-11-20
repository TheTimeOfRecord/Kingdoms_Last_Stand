using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats
{
    //��ž�� ���� ���ݼӼ�
    public List<AttackTypeStat> typeStats = new List<AttackTypeStat>();

    //��ž ��Ÿ�, ���ݼӵ�
    public float currentRange;
    public float currentRate;

    /// <summary>
    /// ��ž �⺻ ��Ÿ�, ���ݼӵ� ���� �޼���
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
