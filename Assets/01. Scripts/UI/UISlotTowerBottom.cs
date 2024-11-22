using System.Collections.Generic;
using UnityEngine;

public class UISlotTowerBottom : UISlotTower
{
    [Header("Slot Right Info")]
    [SerializeField] protected UISlotAttackTypeBottom uiSlotAttackTypeBase;
    [SerializeField] protected Transform attackTypeParent;

    protected List<UISlotAttackTypeBottom> uiSlotAttackTypes = new List<UISlotAttackTypeBottom>();
    private int indexSelectedAtkType = 0;

    public override void InitData(Tower tower)
    {
        base.InitData(tower);
        uiSlotAttackTypes[indexSelectedAtkType].Select();
    }
    public override void SetData(Tower tower)
    {
        base.SetData(tower);
        SetUISlotAttackTypes();
        // TODO : 강화 버튼
    }
    public override void ClearData()
    {
        base.ClearData();
        foreach (var slot in uiSlotAttackTypes)
        {
            slot.gameObject.SetActive(false);
        }
        indexSelectedAtkType = 0;
    }

    // TODO : 강화 비용
    protected override void InitUISlotListAttackType()
    {
        int slotIndex = 0;
        foreach (var attackTypeStat in attackTypeStats)
        {
            if(attackTypeStat.statData.type != AttributeType.Normal)
            {
                // 이미 슬롯이 존재하는 경우 재사용
                if (slotIndex < uiSlotAttackTypes.Count)
                {
                    var existingSlot = uiSlotAttackTypes[slotIndex];
                    existingSlot.SetData(attackTypeStat, tower); // 데이터 업데이트
                    existingSlot.gameObject.SetActive(true); // 활성화
                }
                else
                {
                    // 슬롯이 부족하면 새로 생성
                    InitUISlotAttackType(attackTypeStat);
                }

                slotIndex++;
            }
        }

    }
    protected void InitUISlotAttackType(AttackTypeStat attackTypeStat)
    {
        UISlotAttackTypeBottom slot = Instantiate(uiSlotAttackTypeBase, attackTypeParent);
        slot.SetData(attackTypeStat, tower);
        slot.gameObject.SetActive(true);
        uiSlotAttackTypes.Add(slot);
    }

    public void SetUISlotAttackTypes()
    {
        foreach (var attackTypeStat in attackTypeStats)
        {
            if (attackTypeStat.statData.type != AttributeType.Normal)
            {
                uiSlotAttackTypes[(int)attackTypeStat.statData.type].SetData(attackTypeStat, tower);
            }
        }
    }


    public void AttackTypeSelected(AttributeType atkType)
    {
        uiSlotAttackTypes[indexSelectedAtkType].DisSelect();
        indexSelectedAtkType = (int)atkType;
        uiSlotAttackTypes[indexSelectedAtkType].Select();
    }

    public void OnClickUpgrade()
    {
        if (tower != null && UIManager.Instance.CurrentGold >= tower.statsHandler.UpgradePrice((AttributeType)indexSelectedAtkType))
        {
            UpgradeAttackType();
        }
    }

    private void UpgradeAttackType()
    {
        uiSlotAttackTypes[indexSelectedAtkType].UpgradeAttackType();
    }

    public void OnClickSell()
    {
        if (tower != null)
        {
            SellTower();
        }
    }
    private void SellTower()
    {
        UIManager.Instance.Sell(tower.statsHandler.SellPrice);
        Destroy(tower.gameObject);
        ClearData();
    }
}
