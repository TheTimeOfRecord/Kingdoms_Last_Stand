using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHQ : Tower, IDamageable
{
    [Header("HQ Stats")]
    [SerializeField] private float maxHealth;
    public float CurrentHealth { get; private set; }

    [SerializeField] private float towerSpawnRate;
    private float lastSpawnTime;

    protected override void Awake()
    {
        base.Awake();

        CurrentHealth = maxHealth;
    }

    protected override void Start()
    {
        base.Start();

        GameManager.Instance.HqTower = this;
    }

    protected override void Update()
    {
        base.Update();

        if(Time.time > lastSpawnTime + towerSpawnRate)
        {
            //TODO : 인벤토리에 타워 추가
            AddNormalTower();
            lastSpawnTime = Time.time;
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Max(0, CurrentHealth);
    }

    public void AddNormalTower()
    {
        //TODO : 타워를 늘리는 위치 필요
        //GameManager.Instance.Player.inventory.GetTower(DataManager.Instance.towerPrefabDatabase.TowerList[0]);
    }

    public void StartDamageOverTime(float damage)
    {
        //추가 될 수도 있지만 일단 스킵
    }

    public void ApplySlowDown()
    {
        //아무것도 안합니다...
    }
}
