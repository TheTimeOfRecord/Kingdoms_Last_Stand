using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player
{
    public int CurrentExp { get; private set; }
    private readonly int needLevelupExp = 100;

    public int PlayerLevel { get; private set; }

    public int CurrentGold { get; private set; }

    public InventoryTemp inventory;

    public UnityAction onLevelUp;

    public Player()
    {
        PlayerLevel = 1;
        CurrentExp = 0;
        CurrentGold = 0;

        inventory = new InventoryTemp();
    }

    public void GetExp(int amount)
    {
        CurrentExp = amount;

        if(CurrentExp >= needLevelupExp * PlayerLevel)
        {
            while(CurrentExp >= needLevelupExp * PlayerLevel)
            {
                CurrentExp -= needLevelupExp * PlayerLevel;
                LevelUp();
            }
        }
    }

    public void LevelUp()
    {
        PlayerLevel++;
        //TODO : 특성 선택?
        //TODO 특성선택시 게임 멈춰서 몬스터를 못죽이도록
        onLevelUp?.Invoke();
    }

    public void GetGold(int amount)
    {
        CurrentGold += amount;
    }

    public bool UseGold(int amount)
    {
        if(CurrentGold < amount)
        {
            return false;
        }
        else
        {
            CurrentGold -= amount;
            return true;
        }
    }
}
