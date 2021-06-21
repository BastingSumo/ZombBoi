using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderUserInterFace : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject TraderUI;
    [SerializeField] RectTransform InventoryButtonHolder;
    [SerializeField] GameObject ButtonPrefab;
    [SerializeField] GameObject SellButton;
    [SerializeField] GameObject BuyButton;
    List<GameObject> Buttons = new List<GameObject>();
    public GameObject SelectedTrader;
    Trader TraderScript;


    static TraderUserInterFace instance;
    public static TraderUserInterFace Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else instance = this;
        SellButton.SetActive(false);
        BuyButton.SetActive(false);
    }
    private void Update()
    {
        if (SelectedTrader != null) TraderScript = SelectedTrader.GetComponent<Trader>();
    }
    bool CheckInventoryForSelectedItem(List<GameObject> gameObjects)
    {
        if (gameObjects.Contains(PlayerInventory.Instance.SelectedItem)) return true;
        return false;
    }
    public void BuyItem()
    {
        if (TraderScript != null)
        {
            if (CheckInventoryForSelectedItem(TraderScript.ItemStock) && PlayerInventory.Instance.Coins >= PlayerInventory.Instance.SelectedItem.GetComponent<Item>().GetValue)
            {
                TraderScript.ItemStock.Remove(PlayerInventory.Instance.SelectedItem);
                PlayerInventory.Instance.Coins -= PlayerInventory.Instance.SelectedItem.GetComponent<Item>().GetValue;
                PlayerInventory.Instance.GetInventoryList.Add(PlayerInventory.Instance.SelectedItem);
                OpenBuyingMenu();
            }
        }
    }
    public void SellItem()
    {
        if (TraderScript != null)
        {
            if (CheckInventoryForSelectedItem(PlayerInventory.Instance.GetInventoryList))
            {
                TraderScript.ItemStock.Add(PlayerInventory.Instance.SelectedItem);
                PlayerInventory.Instance.Coins += PlayerInventory.Instance.SelectedItem.GetComponent<Item>().GetValue;
                PlayerInventory.Instance.GetInventoryList.Remove(PlayerInventory.Instance.SelectedItem);
                OpenSellingMenu();
            }
        }
    }
    public void OpenCloseTraderUI()
    {
        if (TraderScript != null)
        {
            if (TraderUI.activeSelf == false)
            {
                if (Buttons != null) ButtonCreator.DestroyButtons(Buttons);
                TraderUI.SetActive(true);
                OpenBuyingMenu();
            }
            else if (TraderUI.activeSelf == true)
            {
                if (Buttons != null) ButtonCreator.DestroyButtons(Buttons);
                TraderUI.SetActive(false);
            }
        }
    }
    public void OpenBuyingMenu()
    {
        if (TraderScript != null) CreateButtons(TraderScript.ItemStock);
        SellButton.SetActive(false);
        BuyButton.SetActive(true);
    }
    public void OpenSellingMenu()
    {
        if (TraderScript != null) CreateButtons(PlayerInventory.Instance.GetInventoryList);
        SellButton.SetActive(true);
        BuyButton.SetActive(false);
    }
    void CreateButtons(List<GameObject> Items)
    {
        if (Buttons != null) ButtonCreator.DestroyButtons(Buttons);
        Buttons = ButtonCreator.CreateButtons(Items, ButtonPrefab, InventoryButtonHolder);
        TraderUI.SetActive(true);
        if (Buttons != null) ButtonCreator.SetPlayerInventoryButtonData(Buttons, Items);
    }
}
