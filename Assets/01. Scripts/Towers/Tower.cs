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
    //public TowerStatsHandler statsHandler = new TowerStatsHandler(this);

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        detector = GetComponent<MonsterDetector>();
    }

    private void Start()
    {
        //stats.InitTowerData(float range, float rate);
        //stats.InitAttackStat(AttackTypeStatListSO typeListData);
    }

    private void Update()
    {
        //Shooter.UpdateAttack();
        //MonsterDetector.UpdateDetect;
    }

    private void Upgrade(int index)
    {
        //stats.typeStats[index].currentdamage = TowerStatsHandler.shootDamage;
        //TowerUpgrade(int index); 버튼으로 업그레이드 연결
    }
}
