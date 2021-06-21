using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    EnemyBrain enemyBrain;
    private void Start()
    {
        enemyBrain = gameObject.GetComponentInParent<EnemyBrain>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyBrain.Target = collision.gameObject;
        }
    }
}
