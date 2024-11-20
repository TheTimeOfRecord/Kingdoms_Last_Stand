using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class UISlotAttackType : MonoBehaviour
{
    [Header("Default Attack Type Data")]
    [SerializeField] protected TMP_Text txtAtkType;
    [SerializeField] protected TMP_Text txtAtkTypeDamage;
    //[SerializeField] protected TMP_Text txtAtkTypeUpgradeCost;
    [SerializeField] protected TMP_Text txtAtkTypeDescription;

    protected Tower tower;
    protected List<AttackTypeStatSO> attackTypeStatList;

    public virtual void SetData(Tower tower)
    {
        this.tower = tower;
        attackTypeStatList = tower.typeListData.AttackLists;
    }
}
public class UISlotAttackTypeBottom : UISlotAttackType
{
    [Header("Bottom Attack Type Data")]
    [SerializeField] protected TMP_Text txtAtkTypeUpgradeCost;
    public override void SetData(Tower tower)
    {
        this.tower = tower;

        //txtAtkType.text = tower.towerData.towerName;
        //txtAtkTypeDamage = tower.
    }
}