using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    public ProjectileSO projectileData;
    private Transform shootPoint;
    [SerializeField] private UnityEvent towerShoot;

    private IObjectPool<Projectile> objectPool;

    private void Awake()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == "ShootPoint")
            {
                shootPoint = child;
                break;
            }
        }
    }

    private void Start()
    {
        objectPool = ObjectPoolManager.Instance.GetProjectilePool();
    }

    public void UpdateAttack(Vector3 targetDirection, TowerStats stats)
    {
        MakeProjectile(targetDirection, stats);
    }

    private void MakeProjectile(Vector3 targetDirection, TowerStats stats)
    {
        Vector3 savePosition = shootPoint.position;
        if (objectPool == null) return;

        for (int index = 0; index < stats.typeStats.Count; index++)
        {
            if (stats.typeStats.Count != 1)
            {
                float randomX = shootPoint.position.x + Random.Range(-0.5f, 0.5f);
                float randomY = shootPoint.position.y + Random.Range(-0.5f, 0.5f);
                savePosition = new Vector3(randomX, randomY, 0);
            }
            if (stats.typeStats[index].isActive)
            {
                Projectile projectileObject = objectPool.Get();
                if (projectileObject == null) return;
                projectileObject.SetPosition(savePosition, targetDirection);
                projectileObject.SetProjectileProperties(stats, stats.typeStats[index], projectileData);
                projectileObject.Shoot(targetDirection);
                projectileObject.Deactivate();
            }
        }
    }
}
