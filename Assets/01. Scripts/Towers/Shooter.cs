using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    public ProjectileSO projectileData;

    [SerializeField] private UnityEvent towerShoot;

    private IObjectPool<Projectile> objectPool;

    private void Awake()
    {
        objectPool = ObjectPoolManager.Instance.GetProjectilePool();
    }

    public void UpdateAttack(Vector3 targetDirection, TowerStats stats)
    {
        MakeProjectile(targetDirection, stats);

    }

    private void MakeProjectile(Vector3 targetDirection, TowerStats stats)
    {
        if (objectPool != null) return;

        for (int index = 0; index < stats.typeStats.Count; index++)
        {
            if (stats.typeStats[index].isActive)
            {
                Projectile projectileObject = objectPool.Get();
                if (projectileObject == null) return;
                projectileObject.SetPosition(transform.position, targetDirection);
                projectileObject.SetProjectileProperties(stats, stats.typeStats[index], projectileData);
                projectileObject.Shoot(targetDirection);
                projectileObject.Deactivate();
            }
        }
    }
    //TODO 탄 6개 출발위치세팅로직?
}
