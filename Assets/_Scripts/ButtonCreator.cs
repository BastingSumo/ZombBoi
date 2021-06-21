using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class ButtonCreator
{
    // converts a list of Item to ui buttons and gives the buttons a function
    public static List<GameObject> CreateButtons(List<GameObject> ListOfItems, GameObject ButtonPrefab, RectTransform ButtonParent)
    {
        if (ListOfItems.Count > 0)
        {
            List<GameObject> ListOfButtons = new List<GameObject>();
            for (int i = 0; i < ListOfItems.Count; i++)
            {
                GameObject obj = Object.Instantiate(ButtonPrefab);
                obj.transform.SetParent(ButtonParent.transform, false);
                if (!ListOfButtons.Contains(obj))
                {
                    ListOfButtons.Add(obj);
                }
            }
            return ListOfButtons;
        }
        return null;
    }
    public static void DestroyButtons(List<GameObject> Buttons)
    {
        if (Buttons.Count > 0)
        {
            foreach (GameObject item in Buttons)
            {
                Object.Destroy(item);
            }
            Buttons.Clear();
        }
    }
    public static void SetPlayerInventoryButtonData(List<GameObject> Buttons, List<GameObject> Inventory)
    {
        if (Buttons.Count > 0 && Inventory.Count > 0)
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                InventoryButton buttonScript = Buttons[i].GetComponent<InventoryButton>();
                Item itemScript = Inventory[i].GetComponent<Item>();
                buttonScript.Name.text = itemScript.GetitemName;
                buttonScript.image.sprite = itemScript.GetSpriteRenderer.sprite;
                buttonScript.ActualItem = Inventory[i];
            }
        }
    }
}
