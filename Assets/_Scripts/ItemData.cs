using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    string itemname;
    int quantity;
    // Holds all modifiers for an item such as its armor value or its damage value
    Dictionary<ItemDataBase.Modifier,float> modifiers;



    public ItemData(string itemname, int quantity = 1)
    {
        this.itemname = itemname;
        this.quantity = quantity;
    }

    public ItemData(string itemname, Dictionary<ItemDataBase.Modifier,float> modifier, int quantity = 1)
    {
        this.itemname = itemname;
        this.modifiers = modifier;
        this.quantity = quantity;
    }
}
