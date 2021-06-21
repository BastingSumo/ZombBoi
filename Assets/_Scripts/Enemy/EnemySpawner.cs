using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject DefaultEnemy;
    [SerializeField] List<GameObject> SpawnLocations = new List<GameObject>();
    [SerializeField] float SpawnAfterSeconds = 2;
    float timer = 0;

    private void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer > SpawnAfterSeconds)
        {
            Instantiate(DefaultEnemy, SpawnLocations[Random.Range(0,SpawnLocations.Count)].transform.position, Quaternion.identity, gameObject.transform);
            timer = 0;
        }
    }
}
