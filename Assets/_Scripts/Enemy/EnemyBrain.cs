using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public GameObject Target;
    EnemyCombat enemyCombat;
    EnemyMovement enemyMovement;
    EnemyAnimation enemyAnimation;

    public enum AllEnemyStates {Idle, ChasingPlayer, Attacking, Stunned, Dead }
    public AllEnemyStates CurrentEnemyState = AllEnemyStates.Idle;

    [Header("Animation Settings")]
    [SerializeField] Animator animator;

    [Header("MovementSettings")]
    [SerializeField] float MoveSpeed = 3;

    [Header("CombatSettings")]
    [SerializeField] float AttackDamage = 10;
    [SerializeField] float AttackSpeed = 10;
    [SerializeField] float AttackRange = 10;
    [SerializeField] float DamageReduction = 2;

    public float GetDamageReduction { get => DamageReduction; }


    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        enemyCombat = new EnemyCombat(AttackDamage, AttackSpeed, AttackRange);
        enemyMovement = new EnemyMovement(gameObject, this, MoveSpeed);
        enemyAnimation = new EnemyAnimation(gameObject, animator, enemyMovement);
    }
    private void Update()
    {
        StateDecider();
        StateTree();
        enemyAnimation.AnimateMovement();
    }
    void StateDecider()
    {
        if (HasTarget() && !enemyCombat.isInAttackRange(gameObject, Target))
        {
            CurrentEnemyState = AllEnemyStates.ChasingPlayer;
        }
        else if (HasTarget() && enemyCombat.isInAttackRange(gameObject, Target))
        {
            CurrentEnemyState = AllEnemyStates.Attacking;
        }
        else
        {
            CurrentEnemyState = AllEnemyStates.Idle;
        }
    }
    void StateTree()
    {
        switch (CurrentEnemyState)
        {
            case AllEnemyStates.Idle:
                break;
            case AllEnemyStates.ChasingPlayer:
                enemyMovement.ChasePlayer();
                break;
            case AllEnemyStates.Attacking:
                enemyCombat.Attack(Target);
                break;
            case AllEnemyStates.Stunned:
                break;
            case AllEnemyStates.Dead:
                break;
            default:
                break;
        }
    }
    public bool HasTarget()
    {
        if (Target != null)
        {
            return true;
        }
        return false;
    }
}
