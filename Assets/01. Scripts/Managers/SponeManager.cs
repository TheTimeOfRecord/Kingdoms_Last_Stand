using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class SponeManager : SingleTonBase<SponeManager>
{
    private Dictionary<GameObject, IObjectPool<GameObject>> monsterPools;

    [SerializeField] private int defaultCapacity = 10;
    [SerializeField] private int maxSize = 100;

    protected override void Awake()
    {
        monsterPools = new Dictionary<GameObject, IObjectPool<GameObject>>();
    }

    public void CreatePool(GameObject prefab)
    {
        if (monsterPools.ContainsKey(prefab))
            return;

        monsterPools[prefab] = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(prefab),
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            actionOnDestroy: Destroy,
            collectionCheck: false,
            defaultCapacity: defaultCapacity,
            maxSize: maxSize
        );
    }

    public GameObject GetFromPool(GameObject prefab)
    {
        if (!monsterPools.ContainsKey(prefab))
        {
            return null;
        }

        return monsterPools[prefab].Get();
    }

    public void ReturnToPool(GameObject obj)
    {
        foreach (var key in monsterPools.Keys)
        {
            if (key == obj)
            {
                monsterPools[key].Release(obj);
                return;
            }
        }
    }
}