using UnityEngine;

[CreateAssetMenu(fileName = "AttackTypeStat", menuName = "ScriptableObject/AttackTypeStat", order = 1)]
public class AttackTypeStatSO : ScriptableObject
{
    public AttributeType type;
    public float damage;
    public float upgradeFactor;
    public float upgradeCost;
    public Color typeColor;
}