using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    List<GameObject> Targets = new List<GameObject>();

    private void Update()
    {
        if (Targets.Count > 0)
        {
            if (InputManager.hasPressedInteract())
            {
                if (Targets[0].tag == "Item") PlayerInventory.Instance.AddItemToInventory(Targets[0]);
                else if (Targets[0].tag == "Trader") 
                {
                    TraderUserInterFace.Instance.SelectedTrader = Targets[0];
                    TraderUserInterFace.Instance.OpenCloseTraderUI();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            Item itemscript = collision.GetComponent<Item>();
            itemscript.GetComponent<Item>().EnableDisableInteractionSprite(true);
            if (!Targets.Contains(collision.gameObject)) Targets.Add(collision.gameObject);
        }
        if (collision.tag == "Trader")
        {
            if (!Targets.Contains(collision.gameObject)) Targets.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Targets.Contains(collision.gameObject))
        {
            Targets.Remove(collision.gameObject);
            if (collision.tag == "Item") collision.gameObject.GetComponent<Item>().EnableDisableInteractionSprite(false);
        }
    }
}
