using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class StageManager : MonoBehaviour
{
    [SerializeField] private StageSO stageData; // �������� ������
    [SerializeField] private Transform spawnPoint; // ���� ���� ��ġ

    // �������� �����Ϳ� ���� Ǯ �ʱ�ȭ
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

    // �������� ����
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
