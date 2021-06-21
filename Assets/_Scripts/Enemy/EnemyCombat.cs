using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat
{
    float Damage = 10;
    float AttackSpeed = 1;
    float AttackRange = 5;
    PlayerHealth playerHealth;
    float timer = 0;
    public void Attack(GameObject target)
    {
        if (target != null)
        {
            playerHealth = target.gameObject.GetComponentInParent<PlayerHealth>();
            timer += 1 * Time.deltaTime;
            if (timer > AttackSpeed)
            {
                float damage = Damage;
                damage -= target.GetComponentInParent<PlayerCombat>().GetDamageReduction;
                playerHealth.CurrentHealth -= damage;
                timer = 0;
            }
        }
    }
    public EnemyCombat(float Damage, float AttackSpeed, float AttackRange)
    {
        this.Damage = Damage;
        this.AttackSpeed = AttackSpeed;
        this.AttackRange = AttackRange;
    }
    public bool isInAttackRange(GameObject target, GameObject thisEnemy) => Vector3.Distance(thisEnemy.transform.position, target.transform.position) < AttackRange;
}
