using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int CurrentExp { get; private set; }
    private readonly int needLevelupExp = 100;

    public int PlayerLevel { get; private set; }

    public int CurrentGold { get; private set; }

    public InventoryTemp inventory;

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
        //TODO : Ư�� ����?
        //TODO Ư�����ý� ���� ���缭 ���͸� �����̵���
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
