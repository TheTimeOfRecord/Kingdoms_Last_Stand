using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ProjectileSO", menuName = "ScriptableObject/Projectile", order = 3)]
public class ProjectileSO : ScriptableObject
{
    public float shootSpeed;
    public Sprite projectileSprite;
}