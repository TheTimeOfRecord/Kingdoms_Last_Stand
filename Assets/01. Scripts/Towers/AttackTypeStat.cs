using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class AttackTypeStat
{
    public int upgradeCount = 0;
    public bool isActive = false;
    public float currentDamage => statData.damage * Mathf.Pow(statData.upgradeFactor, upgradeCount);
    public AttackTypeStatSO statData;

    public AttackTypeStat(AttackTypeStatSO dataSO)
    {
        statData = dataSO;
    }
}
