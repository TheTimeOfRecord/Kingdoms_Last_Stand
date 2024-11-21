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
        base.Awake();

        Player = new Player();
    }

    public void AddGold(int amount)
    {
        Player.GetGold(amount);
    }

    public void AddExp(int amount)
    {
        Player.GetExp(amount);
    }

    public void GameOver()
    {
        if(HqTower.CurrentHealth <= 0)
        {
            IsGameOver = true;
        }
    }
}
