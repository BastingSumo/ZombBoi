using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    [SerializeField] float HealthRestore;

    public override void Use(GameObject item)
    {
        base.Use(item);
        GameManager.Instance.GetCurrentPlayerObject.GetComponent<PlayerHealth>().CurrentHealth += HealthRestore;
        item.gameObject.SetActive(true);
        PlayerInventory.Instance.DestoryButton(item);
        PlayerInventory.Instance.RemoveItem(item);
        Destroy(item);
    }
}
