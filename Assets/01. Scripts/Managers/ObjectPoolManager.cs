using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : SingleTonBase<ObjectPoolManager>
{
    private IObjectPool<Projectile> projectilePool;

    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 200;

    protected override void Awake()
    {
        base.Awake();

        projectilePool = new ObjectPool<Projectile>(CreateProjectile,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                collectionCheck, defaultCapacity, maxSize);
    }

    private Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.ObjectPool = projectilePool;
        return projectileInstance;
    }

    private void OnReleaseToPool(Projectile pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnGetFromPool(Projectile pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnDestroyPooledObject(Projectile pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    public IObjectPool<Projectile> GetProjectilePool()
    {
        return projectilePool;
    }
}