using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTonBase<GameManager>
{
    public TowerHQ HqTower;

    public bool IsGameOver { get; private set; }

    public void GameOver()
    {
        if(HqTower.CurrentHealth <= 0)
        {
            IsGameOver = true;
        }
    }
}
