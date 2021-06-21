using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<int, ItemData> inventory = new Dictionary<int, ItemData>()
    {
        {0, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {1, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {2, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {3, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {4, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {5, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {6, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {7, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
        {8, ItemDataBase.ItemData[ItemDataBase.item.Empty]},
    };
}
