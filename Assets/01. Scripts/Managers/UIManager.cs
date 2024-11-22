using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingleTonBase<UIManager>
{
    [Header("UI Right Info")]
    [SerializeField] private TMP_Text txtCurrentGold;
    [SerializeField] private float currentGold;
    public float CurrentGold 
    {
        get { return currentGold; }
        private set { currentGold = value; }
    }

    [Header("UI Left Info")]
    [SerializeField] private TMP_Text txtStage;
    [SerializeField] private TMP_Text txtStageDescription;
    [SerializeField] private TMP_Text txtLevel;
    [SerializeField] private Image forwardExpBar;

    [Header("UI Buttom Info")]
    [SerializeField] private UISlotTowerBottom uiSlotTowerBottom;

    private void Start()
    {
        SetAllUI();
    }
    public void SetAllUI()
    {
        SetRightUI();
        SetLeftUI();
        SetBottomUI();
    }

    public void SetRightUI()
    {
        txtCurrentGold.text = $"º¸À¯ °ñµå: {currentGold}G";
    }
    public void SetLeftUI() 
    {

    }
    public void SetBottomUI()
    {

    }

    public void OnClickTowerCombination()
    {
        TowerCombination();
    }
    private void TowerCombination()
    {

    }

    public bool Buy(float amountGold)
    {
        if (CurrentGold >= amountGold)
        {
            CurrentGold -= amountGold;
            SetRightUI();
            return true;
        }
        return false;
    }
    public bool Sell(float amountGold)
    {
        CurrentGold += amountGold;
        SetRightUI();
        return true;
    }
}
