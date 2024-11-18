using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ProjectileSO", menuName = "ScriptableObject/ProjectileSO", order = 1)]
public class TowerSO : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private Sprite towerImage;
    [SerializeField] private float towerUpgradePrice;
    [SerializeField] private ProjectileType type;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
}
