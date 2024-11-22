using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterSpawnInfo
{
    public GameObject monsterPrefab;
    public int count;
    public float spawnInterval;
}

[CreateAssetMenu(fileName = "StageData", menuName = "SystemSO/StageData")]
public class StageSO : ScriptableObject
{
    public List<MonsterSpawnInfo> monstersToSpawn;
}
