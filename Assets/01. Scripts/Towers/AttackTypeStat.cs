using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypeStat
{
    public int upgradeCount = 0;
    public bool hasType = false;
    public float currentDamage = 0;
    public AttackTypeStatSO statData;

    public AttackTypeStat(AttackTypeStatSO dataSO)
    {
        statData = dataSO;
    }
}
