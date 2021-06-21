using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Value;
    public Image image;
    public GameObject ActualItem;

    private void Start()
    {
        Value.text = ActualItem.GetComponent<Item>().GetValue.ToString();
    }
    public void Drop()
    {
        PlayerInventory.Instance.DropItem(ActualItem);
    }
    public void Use()
    {
        PlayerInventory.Instance.UseItemInInventory(ActualItem);
    }
    public void Assign()
    {
        PlayerInventory.Instance.AssignItemToSlot(ActualItem);
    }
    public void Select()
    {
        PlayerInventory.Instance.SelectedItem = ActualItem;
    }
}
