using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class StageManager : MonoBehaviour
{
    [SerializeField] private List<StageSO> stageData;
    [SerializeField] private Transform spawnPoint;
    private int stage = 0;

    private void InitializePools()
    {
        foreach (MonsterSpawnInfo spawnInfo in stageData[stage].monstersToSpawn)
        {
            if (spawnInfo.monsterPrefab == null)
            {
                continue;
            }

            SponeManager.Instance.CreatePool(spawnInfo.monsterPrefab);
        }
    }

    public void StartStage()
    {
        if(stage < stageData.Count)
        {
            InitializePools();
            foreach (MonsterSpawnInfo spawnInfo in stageData[stage].monstersToSpawn)
            {
                StartCoroutine(SpawnMonsters(spawnInfo));
            }
            stage++;
        }
    }

    private IEnumerator SpawnMonsters(MonsterSpawnInfo monsters)
    {
        for (int i = 0; i < monsters.count; i++)
        {
            GameObject monster = SponeManager.Instance.GetFromPool(monsters.monsterPrefab);
            if (monster != null)
            {
                monster.transform.position = spawnPoint.position;
            }

            yield return new WaitForSeconds(monsters.spawnInterval);
        }
    }
}
