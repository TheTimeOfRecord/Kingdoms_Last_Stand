using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonsterDetector : MonoBehaviour
{
    private Transform HQTowerPosition;
    private Vector3 closestMonsterDirection;
    private Collider2D[] detectedMonsters = new Collider2D[15];
    private LayerMask layerMask;
    private float towerAttackRange;

    private void Awake()
    {
        HQTowerPosition = GameManager.Instance.HqTower.gameObject.transform;
        layerMask = LayerMask.GetMask("Enemy");
    }

    public void InitMonsterDetector(float range)
    {
        towerAttackRange = range;
    }

    public Vector3 UpdateDetect()
    {
        return DetectedMonstor();
    }

    private Vector3 DetectedMonstor()
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, towerAttackRange, detectedMonsters, layerMask);
        if (hitCount == 0) return Vector3.zero;

        float minDistance = float.MaxValue;
        Vector3 closestMonsterPosition = transform.position;

        for (int i = 0; i < hitCount; i++)
        {
            Collider2D monster = detectedMonsters[i];
            if (monster != null)
            {
                float distance = Vector2.Distance(transform.position, monster.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestMonsterPosition = monster.transform.position;
                }
            }
        }

        closestMonsterDirection = closestMonsterPosition - transform.position;
        return closestMonsterDirection;
        //TODO 
        //Overlap으로 계속 부를지
    }
}
