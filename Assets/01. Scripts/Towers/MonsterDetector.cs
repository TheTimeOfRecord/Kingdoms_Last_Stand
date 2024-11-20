using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
    public Transform[] target;
    public Transform monsterPosition;
    private float searchRate = 0.5f;
    private float towerAttackRange;
    private Collider2D[] detectedMonsters;
    private LayerMask layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Enemy");
        detectedMonsters = new Collider2D[15];
    }

    public void InitMonsterDetector(float range)
    {
        towerAttackRange = range;
    }

    public Vector2 UpdateDetect()
    {
        return DetectedMonstor();
    }

    private Vector2 DetectedMonstor()
    {
        if (target == null) return Vector2.zero;
        int hits = Physics2D.OverlapCircleNonAlloc(transform.position, towerAttackRange, detectedMonsters, layerMask);
        return Vector2.zero;
        //float distance = detectedMonsters[n].gameObject.Nav 
        //Overlap으로 계속 부를지
    }
}
