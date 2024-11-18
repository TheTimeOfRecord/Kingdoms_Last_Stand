using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSO", menuName = "ScriptableObject/ProjectileSO", order = 1)]
public class ProjectileSO : ScriptableObject
{
    [SerializeField] private ProjectileType type;
    [SerializeField] private float shootSpeed;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Color effectColor;
}