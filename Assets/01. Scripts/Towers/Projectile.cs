using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    private AttributeLogicStateMachine attributeLogicStateMachine;
    private ProjectileSO projectileData = null;
    private AttributeLogics attributeLogic = null;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;
    private Rigidbody2D projectileRigidbody;
    private Outline outline;
    private float speed;
    private float damage;
    private float attackRange;
    private bool isReleased = false;
    [SerializeField] private float timeoutDelay = 3f;

    private IObjectPool<Projectile> objectPool;
    public IObjectPool<Projectile> ObjectPool { set => objectPool = value; }

    private void Awake()
    {
        attributeLogicStateMachine = new AttributeLogicStateMachine();
        attributeLogicStateMachine.Initialize();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        projectileRigidbody = GetComponent<Rigidbody2D>();
        outline = GetComponent<Outline>();
    }

    public void SetPosition(Vector3 towerPosition, Vector3 targetDirection)
    {
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(towerPosition, Quaternion.Euler(0, 0, angle));//Quaternion.Euler(0, 0, angle)
    }

    public void SetProjectileProperties(TowerStats stats, AttackTypeStat attackType, ProjectileSO data)
    {
        isReleased = false;
        projectileData = data;
        speed = projectileData.shootSpeed;
        damage = attackType.currentDamage;
        attackRange = stats.currentRange;

        outline.effectColor = attackType.statData.typeColor;
        trailRenderer.startColor = attackType.statData.typeColor;
        trailRenderer.endColor = Color.white;
        spriteRenderer.sprite = projectileData.projectileSprite;

        attributeLogic = attributeLogicStateMachine.GetAttributeLogic(attackType.statData.type);
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
                //damageable.TakeDamage(damage);
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
