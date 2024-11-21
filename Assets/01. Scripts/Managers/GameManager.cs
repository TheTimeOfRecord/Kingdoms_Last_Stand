using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTonBase<GameManager>
{
    public TowerHQ HqTower { get; set; }

    public bool IsGameOver { get; private set; }

    public Player Player { get; private set; }

    protected override void Awake()
    {
        Player = new Player();
    }

    public void GameOver()
    {
        if(HqTower.CurrentHealth <= 0)
        {
            IsGameOver = true;
        }
    }
}
