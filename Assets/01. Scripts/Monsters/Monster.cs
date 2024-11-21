using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Run,
    Attacking,
    Dead,
    Hit
}

public class Monster : MonoBehaviour, IDamageable
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private AIState currentState = AIState.Idle;
    private float currentHealth;
    private Transform mainTarget;

    [SerializeField] private MonsterStatsSO monsterStats;
    private IObjectPool<Monster> objectPool;
    public IObjectPool<Monster> ObjectPool { set => objectPool = value; }

    private WaitForSeconds ticRate;
    private float ticTimer = 10f;
    private Coroutine ticDamageCoroutine;

    private float slowAmount = 0.5f;
    private Coroutine slowCoroutine;
    private WaitForSeconds slotTime;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

        ticRate = new WaitForSeconds(0.3f);
        slotTime = new WaitForSeconds(10f);
    }

    void Start()
    {
        mainTarget = GameManager.Instance.HqTower.transform;

        currentHealth = monsterStats.maxHealth;

        navMeshAgent.speed = monsterStats.moveSpeed;

        ChangeState(AIState.Run);
    }

    void Update()
    {
        switch (currentState)
        {
            case AIState.Run:
                WalkingBehavior();
                break;
            case AIState.Attacking:
                AttackingBehavior();
                break;
            case AIState.Hit:
                break;
            case AIState.Dead:
                break;
        }
    }

    private void WalkingBehavior()
    {
        if (mainTarget != null)
        {
            navMeshAgent.SetDestination(mainTarget.position);

            float distanceToTarget = Vector3.Distance(transform.position, mainTarget.position);
            if (distanceToTarget <= monsterStats.attackRange)
            {
                ChangeState(AIState.Attacking);
            }
        }
    }

    private void AttackingBehavior()
    {
        if (mainTarget != null)
        {
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Attack");

            Invoke(nameof(DealDamageToCastle), 1 / monsterStats.attackSpeed);
        }
    }

    private void DealDamageToCastle()
    {
        if (mainTarget != null && currentState == AIState.Attacking)
        {
            GameManager.Instance.HqTower.TakeDamage(monsterStats.attackDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentState == AIState.Dead) return;

        currentHealth -= damage;
        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            ChangeState(AIState.Dead);
            Die();
        }
        else
        {
            ChangeState(AIState.Hit);
        }
    }

    private void Die()
    {
        navMeshAgent.isStopped = true;
        animator.SetTrigger("Death");

        GameManager.Instance.AddGold(monsterStats.goldDrop);
        GameManager.Instance.AddExp(monsterStats.expDrop);

        Invoke(nameof(ReturnToPool), 2f);
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void ChangeState(AIState newState)
    {
        if (currentState == newState) return;
        currentState = newState;

        switch (newState)
        {
            case AIState.Idle:
                animator.SetBool("Run", false);
                navMeshAgent.isStopped = true;
                break;
            case AIState.Run:
                animator.SetBool("Run",true);
                navMeshAgent.isStopped = false;
                break;
            case AIState.Attacking:
                animator.SetTrigger("Attack");
                break;
            case AIState.Dead:
                animator.SetTrigger("Death");
                navMeshAgent.isStopped = true;
                break;
        }
    }

    public void StartDamageOverTime(float damage)
    {
        if (ticDamageCoroutine != null) return;

        ticDamageCoroutine = StartCoroutine(TakeTicDamage(damage));
    }

    public void ApplySlowDown()
    {
        if(slowCoroutine != null) return;

        slowCoroutine = StartCoroutine(TakeSlotDown());
    }

    private IEnumerator TakeTicDamage(float damage)
    {
        float timer = ticTimer;
        while(timer >= 0)
        {
            TakeDamage(damage);
            yield return ticRate;
            timer -= 0.3f;
        }

        ticDamageCoroutine = null;
    }

    private IEnumerator TakeSlotDown()
    {
        navMeshAgent.speed = monsterStats.moveSpeed * slowAmount;
        yield return slotTime;
        navMeshAgent.speed = monsterStats.moveSpeed;

        slowCoroutine = null;
    }
}
