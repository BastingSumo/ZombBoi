using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation
{
    Animator animator;
    GameObject enemy;
    EnemyMovement enemyMovement;


    public void AnimateMovement()
    {
        animator.SetBool("Up", enemyMovement.isMovingUp());
        animator.SetBool("Down", enemyMovement.isMovingDown());
        if (enemyMovement.isMovingRight())
        {
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("RightorLeft", true);
        }
        else if (enemyMovement.isMovingLeft())
        {
            enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("RightorLeft", true);
        }
        else
        {
            animator.SetBool("RightorLeft", false);
        }
    }
    public EnemyAnimation(GameObject enemy, Animator animator, EnemyMovement enemyMovement)
    {
        this.enemy = enemy;
        this.animator = animator;
        this.enemyMovement = enemyMovement;
    }
}
