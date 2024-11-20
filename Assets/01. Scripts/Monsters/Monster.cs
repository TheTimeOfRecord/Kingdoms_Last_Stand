using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Walking,
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

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        mainTarget = GameManager.Instance.castle.transform;

        currentHealth = monsterStats.maxHealth;

        navMeshAgent.speed = monsterStats.moveSpeed;

        ChangeState(AIState.Walking);
    }

    void Update()
    {
        switch (currentState)
        {
            case AIState.Walking:
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
            GameManager.Instance.castle.TakeDamage(monsterStats.attackDamage);
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
                animator.SetTrigger("Idle");
                navMeshAgent.isStopped = true;
                break;
            case AIState.Walking:
                animator.SetTrigger("Run");
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
}
