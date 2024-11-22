using System.Collections.Generic;
using UnityEngine;

public class UISlotTowerRight : UISlotTower
{
    [Header("Slot Right Info")]
    [SerializeField] protected Transform attackTypeParent;
    [SerializeField] protected UISlotAttackTypeRight uiSlotAttackTypeBase;

    protected List<UISlotAttackTypeRight> uiSlotAttackTypes = new List<UISlotAttackTypeRight>();
    public override void SetData(Tower tower)
    {
        base.SetData(tower);
        this.gameObject.SetActive(true);
    }
    protected override void InitUISlotListAttackType()
    {

        foreach (var attackTypeStat in attackTypeStats)
        {
            if(attackTypeStat.isActive == true && attackTypeStat.statData.type != AttributeType.Normal)
            {
                InitUISlotAttackType(attackTypeStat);
            }
        }

    }
    protected void InitUISlotAttackType(AttackTypeStat attackTypeStat)
    {
        UISlotAttackTypeRight slot = Instantiate(uiSlotAttackTypeBase, attackTypeParent);
        slot.SetData(attackTypeStat, tower);
        slot.gameObject.SetActive(true);
        uiSlotAttackTypes.Add(slot);
    }
}