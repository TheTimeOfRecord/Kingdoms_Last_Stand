using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UISlotTower : MonoBehaviour
{
    [Header("Default Tower Info")]
    [SerializeField] protected Image iconTower;
    [SerializeField] protected TMP_Text txtTowerName;
    [SerializeField] protected TMP_Text txtTowerAtkRange;
    [SerializeField] protected TMP_Text txtTowerAtkDamage;
    [SerializeField] protected TMP_Text txtTowerAtkSpeed;
    [SerializeField] protected TMP_Text txtTowerDescription;


    protected Tower tower;
    protected List<AttackTypeStat> attackTypeStats;
    protected AttackTypeStat baseAttackStat;

    public virtual void InitData(Tower tower)
    {
        this.tower = tower;

        if (tower.stats == null)
        {
            Debug.LogError($"Tower.stats is null for tower: {tower.towerData?.towerName}");
            return;
        }

        if (tower.stats.typeStats == null || tower.stats.typeStats.Count == 0)
        {
            Debug.LogError($"Tower.stats.typeStats is null or empty for tower: {tower.towerData?.towerName}");
            return;
        }

        this.attackTypeStats = tower.stats.typeStats;
        SetBaseAttackStat();
        InitUISlotListAttackType();

        SetData(tower);
    }

    public virtual void SetData(Tower tower)
    {
        iconTower.sprite = tower.towerData.towerImage;
        txtTowerName.text = $"{tower.towerData.towerName}";
        txtTowerAtkRange.text = $"사거리: {tower.towerData.attackRange}";
        txtTowerAtkDamage.text = $"공격력: {baseAttackStat.currentDamage.ToString("F1")}";
        txtTowerAtkSpeed.text = $"공격속도: {tower.towerData.attackRate}";
        txtTowerDescription.text = $"{tower.towerData.description}";

    }

    public virtual void ClearData()
    {
        tower = null;
        attackTypeStats = null;
        baseAttackStat = null;
        iconTower.sprite = null;
        txtTowerName.text = "-";
        txtTowerAtkRange.text = $"사거리: -";
        txtTowerAtkDamage.text = $"공격력: -";
        txtTowerAtkSpeed.text = $"공격속도: -";
        txtTowerDescription.text = "팔렸습니다.";
    }

    protected void SetBaseAttackStat()
    {
        baseAttackStat = ReturnStatByType(AttributeType.Normal);
    }
    protected abstract void InitUISlotListAttackType();

    public AttackTypeStat ReturnStatByType(AttributeType type)
    {
        for (int i = 0; i < attackTypeStats.Count; i++)
        {
            if (attackTypeStats[i].statData.type == type)
            {
                return attackTypeStats[i];
            }
        }

        return null;
    }
}
