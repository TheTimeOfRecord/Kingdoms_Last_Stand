using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObject/Tower", order = 0)]
public class TowerSO : ScriptableObject
{
    public string towerName;
    public string description;
    public Sprite towerImage;
    public float attackRange;
    public float attackRate;
}
