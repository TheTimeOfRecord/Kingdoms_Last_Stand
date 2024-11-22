using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlotAttackTypeBottom : UISlotAttackType
{
    [Header("Bottom Attack Type Data")]
    [SerializeField] protected TMP_Text txtAtkTypeUpgradeCost;
    [SerializeField] protected UISlotTowerBottom slotTowerBottom;

    private TowerStatsHandler towerStatsHandler;
    private Outline outline;
    private bool isSelected = false;

    protected override void Awake()
    {
        base.Awake();
        outline = GetComponent<Outline>();
    }
    public override void SetData(AttackTypeStat attackTypeData, Tower tower)
    {
        base.SetData(attackTypeData, tower);
        towerStatsHandler = tower.statsHandler;
        // TODO : Set txtAtkTypeUpgradeCost
        txtAtkTypeUpgradeCost.text = $"강화 비용: {towerStatsHandler.UpgradePrice(attackType)}G";
    }

    public void UpgradeAttackType()//공격 타입 업그레이드
    {

        UIManager.Instance.Buy(towerStatsHandler.UpgradePrice(attackType));
        towerStatsHandler.AddUpgradePrice(attackType);
        if (towerStatsHandler.TypeUpgrade(attackType))//업글 성공
        {
            SetData(attackTypeData, tower);
        }
        else//업글 실패 -> 비용 반환
        {
            UIManager.Instance.Sell(towerStatsHandler.UpgradePrice(attackType));
        }
    }

    public void OnClickListener()
    {
        slotTowerBottom.AttackTypeSelected(attackTypeData.statData.type);
        slotTowerBottom.SetData(tower);
    }
    public void Select()
    {
        isSelected = true;
        SetOutLine();
    }
    public void DisSelect()
    {
        isSelected = false;
        SetOutLine();
    }

    private void SetOutLine()
    {
        if (isSelected)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }
}
