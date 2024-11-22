using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class UISlotAttackType : MonoBehaviour
{
    [Header("Default Attack Type Info")]
    [SerializeField] protected TMP_Text txtAtkType;
    [SerializeField] protected TMP_Text txtAtkTypeDamage;
    [SerializeField] protected TMP_Text txtAtkTypeDescription;

    protected Tower tower;
    protected AttackTypeStat attackTypeData;
    protected AttributeType attackType;

    protected virtual void Awake()
    {
        
    }

    public virtual void SetData(AttackTypeStat attackTypeData, Tower tower)
    {
        this.tower = tower;
        this.attackTypeData = attackTypeData;
        attackType = attackTypeData.statData.type;
        // TODO : Set txtAtkType , txtAtkTypeDamage , txtAtkTypeDescription
        txtAtkType.text = $"{attackTypeData.statData.typeKorName} +{attackTypeData.upgradeCount}";
        txtAtkTypeDamage.text = $"°ø°Ý·Â {attackTypeData.currentDamage.ToString("F1")}";
        txtAtkTypeDescription.text = attackTypeData.statData.typeDescription;
    }


}
