using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTonBase<GameManager>
{
    public TowerHQ HqTower { get; set; }

    public bool IsGameOver { get; private set; }

    [SerializeField] public TowerHQ castle;

    private int totalGold = 0;

    public void AddGold(int amount)
    {
        totalGold += amount;
        Debug.Log($"Gold collected: {totalGold}");
    }

    public void GameOver()
    {
        if(HqTower.CurrentHealth <= 0)
        {
            IsGameOver = true;
        }
    }
}
