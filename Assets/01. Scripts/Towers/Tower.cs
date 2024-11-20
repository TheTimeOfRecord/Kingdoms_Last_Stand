using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public AttackTypeStatListSO typeListData;
    public TowerSO towerData;
    public Shooter shooter;
    public MonsterDetector detector;
    public TowerStats stats = new TowerStats();
    public TowerStatsHandler statsHandler;
    private float detectInterval;
    private float detectTimer = 0f;

    protected virtual void Awake()
    {
        shooter = GetComponent<Shooter>();
        detector = GetComponent<MonsterDetector>();
        statsHandler = new TowerStatsHandler(this);
    }

    protected virtual void Start()
    {
        stats.InitTowerData(towerData.attackRange, towerData.attackRate);
        stats.InitAttackStats(typeListData);
        detector.InitMonsterDetector(towerData.attackRange);
        detectInterval = stats.currentRate;
    }

    protected virtual void Update()
    {
        detectTimer += Time.deltaTime;
        detector.UpdateDetect();
        if (detectTimer >= detectInterval)
        {
            detectTimer = 0f;
            detector.UpdateDetect();
            if (detector.UpdateDetect() != Vector3.zero)
            {
                shooter.UpdateAttack(detector.UpdateDetect(), stats);
            }
        }
    }

    private void Upgrade(int index)
    {
        //stats.typeStats[index].currentdamage = TowerStatsHandler.shootDamage;
        //TowerUpgrade(int index); 버튼으로 업그레이드 연결
    }
}
