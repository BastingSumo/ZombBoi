using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2d;
    float Velocity = 10;
    float Damage;

    public float SetDamage { set => Damage = value; }
    public float SetVelocity { set => Velocity = value; }

    private void Start()
    {
        rigidbody2d.velocity = gameObject.transform.right * Velocity;
        StartCoroutine(DieAfter());
    }
    IEnumerator DieAfter()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float damage = Damage;
            damage -= collision.gameObject.GetComponent<EnemyBrain>().GetDamageReduction;
            collision.gameObject.GetComponent<Health>().CurrentHealth -= damage;
            rigidbody2d.velocity = Vector3.zero;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }
}
