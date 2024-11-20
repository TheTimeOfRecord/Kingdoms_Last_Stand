using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHQ : Tower
{
    [SerializeField]
    private float maxHealth;
    public float CurrentHealth { get; private set; }

    protected override void Start()
    {
        base.Start();

        GameManager.Instance.HqTower = this;
    }
}
