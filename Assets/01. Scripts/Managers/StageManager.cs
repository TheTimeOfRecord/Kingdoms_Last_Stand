using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class StageManager : MonoBehaviour
{
    [SerializeField] private StageSO stageData; // 스테이지 데이터
    [SerializeField] private Transform spawnPoint; // 몬스터 스폰 위치

    // 스테이지 데이터에 따라 풀 초기화
    private void InitializePools()
    {
        foreach (var spawnInfo in stageData.monstersToSpawn)
        {
            if (spawnInfo.monsterPrefab == null)
            {
                Debug.LogError("Monster prefab is null in StageSO. Skipping...");
                continue;
            }

            SponeManager.Instance.CreatePool(spawnInfo.monsterPrefab);
        }
    }

    // 스테이지 시작
    public void StartStage()
    {
        InitializePools();
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        foreach (var spawnInfo in stageData.monstersToSpawn)
        {
            for (int i = 0; i < spawnInfo.count; i++)
            {
                GameObject monster = SponeManager.Instance.GetFromPool(spawnInfo.monsterPrefab);
                if (monster != null)
                {
                    monster.transform.position = spawnPoint.position;
                }

                yield return new WaitForSeconds(spawnInfo.spawnInterval);
            }
        }
    }
}
