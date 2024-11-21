using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "SystemSO/StageData")]
public class StageSO : ScriptableObject
{
    [System.Serializable]
    public class MonsterSpawnInfo
    {
        public GameObject monsterPrefab;
        public int count;
        public float spawnInterval;
    }

    public List<MonsterSpawnInfo> monstersToSpawn;
}
