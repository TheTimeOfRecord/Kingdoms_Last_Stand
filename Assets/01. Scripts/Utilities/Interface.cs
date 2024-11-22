public interface IDamageable
{
    void TakeDamage(float damage);

    public void StartDamageOverTime(float damage);

    public void ApplySlowDown();
}
