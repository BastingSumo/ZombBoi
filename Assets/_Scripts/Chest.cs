using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite ChestOpen;
    [SerializeField] Sprite ChestClosed;

    bool HasBeenOpened = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && HasBeenOpened == false) 
        {
            spriteRenderer.sprite = ChestOpen;
            SpawnItems(Mathf.RoundToInt(Random.Range(1, 3)));
            HasBeenOpened = true;
        }
    }
    void SpawnItems(int Amount) 
    {
        for (int i = 0; i < Amount; i++)
        {
            Instantiate(PrefabManager.Instance.GetPrefabItems[Random.Range(0, PrefabManager.Instance.GetPrefabItems.Count)], new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
