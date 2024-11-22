using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats
{
    private readonly int normalTowerListCount = 6;

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
    /// Ÿ���� �޾Ƽ� �ش� Ÿ���� ���������� ��� ��ȯ��, null �� ��ȯ�Ǹ� ����(Ÿ���� �ش� ������ ����)
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
