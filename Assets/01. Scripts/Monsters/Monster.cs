using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum AIState
{
    Idle,
    Walking,
    Attacking,
    Dead
}

[RequireComponent(typeof(MonsterStats))]
public class Monster : MonoBehaviour
{
    private MonsterStats monsterStats;
    private int currentHealth;
    private Transform currentTarget;
    private List<Transform> visitedTargets = new List<Transform>();
    private Transform castle;
    private Transform[] shields;

    private Animator animator;
    private AIState currentState = AIState.Idle;
    private float attackCooldown;


    void Awake()
    {
        // MonsterStats를 같은 오브젝트에서 가져오기
        monsterStats = GetComponent<MonsterStats>();

        if (monsterStats == null)
        {
            Debug.LogError("MonsterStats is not attached to the object!");
            enabled = false;
            return;
        }
    }

    void Start()
    {
        // Initialize runtime stats
        currentHealth = monsterStats.maxHealth;
        attackCooldown = 0f;

        // Initialize references
        animator = GetComponent<Animator>();
        castle = GameObject.FindGameObjectWithTag("Castle").transform;
        shields = GameObject.FindGameObjectsWithTag("Shield").Select(s => s.transform).ToArray();

        SetNextTarget();
    }

    void Update()
    {
        switch (currentState)
        {
            case AIState.Idle:
                IdleBehavior();
                break;
            case AIState.Walking:
                WalkingBehavior();
                break;
            case AIState.Attacking:
                AttackingBehavior();
                break;
            case AIState.Dead:
                break;
        }

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    private void IdleBehavior()
    {
        animator.SetTrigger("Idle");
    }

    private void WalkingBehavior()
    {
        if (currentTarget == null) return;

        animator.SetTrigger("Run");
        Vector2 direction = (currentTarget.position - transform.position).normalized;
        transform.Translate(direction * monsterStats.moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentTarget.position) < 1.0f)
        {
            ChangeState(AIState.Attacking);
        }
    }

    private void AttackingBehavior()
    {
        if (currentTarget == null)
        {
            ChangeState(AIState.Idle);
            return;
        }

        animator.SetTrigger("Attack");

        if (attackCooldown <= 0)
        {
            Debug.Log($"Attacking {currentTarget.name} with {monsterStats.attackDamage} damage!");
            // Add attack logic (e.g., reduce target's health)
            attackCooldown = 1 / monsterStats.attackSpeed;
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hit");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            ChangeState(AIState.Dead);
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Death");
        Debug.Log($"{monsterStats.monsterName} died!");
        Destroy(gameObject, 1f);
    }

    private void SetNextTarget()
    {
        foreach (Transform shield in shields)
        {
            if (!visitedTargets.Contains(shield))
            {
                currentTarget = shield;
                visitedTargets.Add(shield);
                ChangeState(AIState.Walking);
                return;
            }
        }

        currentTarget = castle;
        ChangeState(AIState.Walking);
    }

    private void ChangeState(AIState newState)
    {
        if (currentState == newState) return;
        currentState = newState;
    }
}
