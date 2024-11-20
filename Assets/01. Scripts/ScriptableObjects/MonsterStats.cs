using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterStats", menuName = "Monster/Stats")]
public class MonsterStats : ScriptableObject
{
    public string monsterName;
    public int maxHealth;
    public float moveSpeed;
    public int attackDamage;
    public float attackSpeed;
    public int goldDrop;
}
