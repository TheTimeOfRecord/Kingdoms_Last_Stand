using UnityEngine;

public abstract class AttributeLogics
{
    public virtual bool CanPenetrate => false;
    public abstract void ApplyAttackLogic(GameObject target, float damage);
}

public class ExplosionAttribute : AttributeLogics
{
    int enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
    float explosionRange = 1f;
    private Collider2D[] enemies = new Collider2D[5];
    public override void ApplyAttackLogic(GameObject target, float damage)
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(target.transform.position, explosionRange, enemies, enemyLayer);
        for (int i = 0; i < hitCount; i++)
        {
            IDamageable damageable = enemies[i].gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}

public class PoisonAttribute : AttributeLogics
{
    public override void ApplyAttackLogic(GameObject target, float damage)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            damageable.StartDamageOverTime(damage);
        }
    }
}

public class IceAttribute : AttributeLogics
{
    public override void ApplyAttackLogic(GameObject target, float damage)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            damageable.ApplySlowDown();
        }
    }
}

public class LightingAttribute : AttributeLogics
{
    int enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
    float ShockRange = 3f;
    private Collider2D[] enemies = new Collider2D[10];
    public override void ApplyAttackLogic(GameObject target, float damage)
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(target.transform.position, ShockRange, enemies, enemyLayer);
        for (int i = 0; i < hitCount; i++)
        {
            IDamageable damageable = enemies[i].gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}

public class PierceAttribute : AttributeLogics
{
    public override bool CanPenetrate => true;
    public override void ApplyAttackLogic(GameObject target, float damage)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}

public class NormalAttribute : AttributeLogics
{
    public override void ApplyAttackLogic(GameObject target, float damage)
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}

