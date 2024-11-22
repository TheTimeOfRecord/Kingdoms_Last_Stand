using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    private AttributeLogicState attributeLogicState;
    private ProjectileSO projectileData = null;
    private AttributeLogics attributeLogic = null;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;
    private Rigidbody2D projectileRigidbody;
    private float speed;
    private float damage;
    private float attackRange;
    private bool isReleased = false;

    private IObjectPool<Projectile> objectPool;
    public IObjectPool<Projectile> ObjectPool { set => objectPool = value; }

    private void Awake()
    {
        attributeLogicState = new AttributeLogicState();
        attributeLogicState.Initialize();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        projectileRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetPosition(Vector3 towerPosition, Vector3 targetDirection)
    {
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(towerPosition, Quaternion.Euler(0, 0, angle));
    }

    public void SetProjectileProperties(TowerStats stats, AttackTypeStat attackType, ProjectileSO data)
    {
        isReleased = false;
        projectileData = data;
        speed = projectileData.shootSpeed;
        damage = attackType.currentDamage;
        attackRange = stats.currentRange;

        trailRenderer.startColor = attackType.statData.typeColor;
        trailRenderer.endColor = Color.white;
        spriteRenderer.sprite = projectileData.projectileSprite;

        attributeLogic = attributeLogicState.GetAttributeLogic(attackType.statData.type);
    }

    public void Shoot(Vector3 targetDirection)
    {
        projectileRigidbody.velocity = targetDirection.normalized * speed;
    }

    public void Deactivate()
    {
        Invoke(nameof(DisappearProjectile), attackRange/speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (isReleased) return;

            IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
            
            if (damageable != null)
            {
                attributeLogic?.ApplyAttackLogic(collider.gameObject, damage);

                if (attributeLogic?.CanPenetrate == true)
                {
                    return;
                }
            }

            CancelInvoke(nameof(DisappearProjectile));
            ReleaseObject();
        }
    }

    private void DisappearProjectile()
    {
        if (isReleased) return;
        ReleaseObject();
    }

    private void ReleaseObject()
    {
        isReleased = true;
        trailRenderer.Clear();
        projectileRigidbody.velocity = Vector2.zero;
        objectPool.Release(this);
    }
}
