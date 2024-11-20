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

    protected virtual void Awake()
    {
        shooter = GetComponent<Shooter>();
        detector = GetComponent<MonsterDetector>();
    }

    protected virtual void Start()
    {
        //stats.InitTowerData(float range, float rate); -> 정확한 값 매개변수에 넣기
        //stats.InitAttackStat(AttackTypeStatListSO typeListData);
        //detector.InitMonsterDetector(towerData.attackRange);
    }

    protected virtual void Update()
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
