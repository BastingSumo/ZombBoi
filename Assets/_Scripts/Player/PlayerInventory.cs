using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    static PlayerInventory instance;

    [Header("Inventory Interface")]
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] RectTransform InventoryButtonHolder;
    [SerializeField] GameObject InventoryUI;
    [SerializeField] GameObject ButtonPrefab;
    List<GameObject> Buttons = new List<GameObject>();
    float scrollDistance;
    [SerializeField] TextMeshProUGUI CoinCounter;

    [Header("Inventory")]
    // do not acess this list directly
    [SerializeField] List<GameObject> InventoryList = new List<GameObject>();
    [SerializeField] List<Image> InventoryBarImages = new List<Image>();
    [SerializeField] GameObject[] InventoryBar;
    [SerializeField] GameObject InventoryBarSelector;
    int InventoryBarSelectorPosition = 0;

    public GameObject SelectedItem;
    [SerializeField] int coins = 0;

    GameObject player;

    public static PlayerInventory Instance { get => instance; }
    public List<GameObject> GetInventoryList { get => InventoryList; }
    public int Coins { get => coins; set => coins = value; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        InventoryBar = new GameObject[8];
        InventoryUI.SetActive(false);
        DisableAllInventoryBarImages();
    }
    private void Update()
    {
        GetPlayer();
        ScrollButtonHolder();
        OpenCloseInventory();
        InventoryBarFunction();
        CoinCounter.text = "Coins : " + coins.ToString();
    }
    void DisableAllInventoryBarImages()
    {
        foreach (Image image in InventoryBarImages)
        {
            image.enabled = false;
        }
    }
    void InventoryBarFunction()
    {
        InventoryBarScroll();
        HotBarNumbers();
        RemoveItemFromHotbar();
    }
    void RemoveItemFromHotbar()
    {
        for (int i = 0; i < InventoryBar.Length; i++)
        {
            if (!InventoryList.Contains(InventoryBar[i])) 
            { 
                InventoryBar[i] = null;
                InventoryBarImages[i].sprite = null;
                InventoryBarImages[i].enabled = false;
            }
        }
    }
    public void AssignItemToSlot(GameObject item)
    {
        if (!InventoryBar.Contains(item))
        {
            InventoryBarImages[InventoryBarSelectorPosition].sprite = item.GetComponent<Item>().GetSpriteRenderer.sprite;
            InventoryBarImages[InventoryBarSelectorPosition].enabled = true;
            InventoryBar[InventoryBarSelectorPosition] = item;
        }
    }
    public void HotBarNumbers()
    {
        UseItemInHotBar(key: InputManager.hasPressedOne(), Position: 0);
        UseItemInHotBar(key: InputManager.hasPressedTwo(), Position: 1);
        UseItemInHotBar(key: InputManager.hasPressedThree(), Position: 2);
        UseItemInHotBar(key: InputManager.hasPressedFour(), Position: 3);
        UseItemInHotBar(key: InputManager.hasPressedFive(), Position: 4);
        UseItemInHotBar(key: InputManager.hasPressedSix(), Position: 5);
        UseItemInHotBar(key: InputManager.hasPressedSeven(), Position: 6);
        UseItemInHotBar(key: InputManager.hasPressedEight(), Position: 7);

        UnAssignHotBar(InputManager.hasPressedTilde(), InventoryBarSelectorPosition);
    }
    void UseItemInHotBar(bool key, int Position)
    {
        if (key) 
        {
            InventoryBarSelectorPosition = Position;
            if (InventoryBar[Position] != null && !InventoryIsOpen()) 
            {
                InventoryBar[Position].GetComponent<Item>().Use(InventoryBar[Position]); 
            } 
        }
    }
    void UnAssignHotBar(bool Key, int Positon)
    {
        if (Key)
        {
            Debug.Log("ass");
            InventoryBar[Positon] = null;
            InventoryBarImages[Positon].sprite = null;
            InventoryBarImages[Positon].enabled = false;
        }
    }
    void InventoryBarScroll()
    {
        if (InputManager.hasPressedBarSwitchRight())
        {
            if (InventoryBarSelectorPosition < 7)
            {
                InventoryBarSelectorPosition += 1;
                SetInventoryBarPosition();
            }
            else
            {
                InventoryBarSelectorPosition = 0;
            }
        }
        if (InputManager.hasPressedBarSwitchLeft())
        {
            if (InventoryBarSelectorPosition > 0)
            {
                InventoryBarSelectorPosition -= 1;
            }
            else
            {
                InventoryBarSelectorPosition = 7;
            }
        }
        InventoryBarSelectorPosition = Mathf.Clamp(InventoryBarSelectorPosition, 0, 7);
        SetInventoryBarPosition();
    }
    void SetInventoryBarPosition() => InventoryBarSelector.transform.position = InventoryBarImages[InventoryBarSelectorPosition].transform.position;
    void GetPlayer()
    {
        player = GameManager.Instance.GetCurrentPlayerObject;
    }
    void OpenCloseInventory()
    {
        if (InputManager.hasPressedInventoryKey() && InventoryUI.activeSelf == false)
        {
            if (Buttons != null) ButtonCreator.DestroyButtons(Buttons);
            Buttons = ButtonCreator.CreateButtons(InventoryList, ButtonPrefab, InventoryButtonHolder);
            InventoryUI.SetActive(true);
            if (Buttons != null) ButtonCreator.SetPlayerInventoryButtonData(Buttons, InventoryList);
        }
        else if (InputManager.hasPressedInventoryKey() && InventoryUI.activeSelf == true)
        {
            if (Buttons != null) ButtonCreator.DestroyButtons(Buttons);
            InventoryUI.SetActive(false);
        }
    }
    void ScrollButtonHolder()
    {
        InventoryButtonHolder.localPosition = new Vector3(InventoryButtonHolder.localPosition.x, scrollbar.value * 1000 + 186, InventoryButtonHolder.localPosition.z);
    }
    public void AddItemToInventory(GameObject item)
    {
        if (!InventoryList.Contains(item))
        {
            item.GetComponent<Item>().EnableDisableInteractionSprite(false);
            item.gameObject.SetActive(false);
            InventoryList.Add(item);
        }
    }
    public void RemoveItemFromInventory(GameObject item)
    {
        if (InventoryList.Contains(item))
        {
            InventoryList.Remove(item);
        }
    }
    public void DropItem(GameObject item)
    {
        if (InventoryList.Contains(item))
        {
            DestoryButton(item);
            item.gameObject.transform.position = player.transform.position;
            item.gameObject.SetActive(true);
            InventoryList.Remove(item);
            item.GetComponent<Item>().Drop(item);
        }
    }
    public void UseItemInInventory(GameObject item)
    {
        if (InventoryList.Contains(item))
        {
            item.GetComponent<Item>().Use(item);
        }
    }
    public void DestoryButton(GameObject item)
    {
        if (InventoryList.Count > 0)
        {
            if (InventoryList.Contains(item))
            {
                if (Buttons.Count > 0)
                {
                    GameObject Button = Buttons[InventoryList.IndexOf(item)];
                    Buttons.Remove(Button);
                    Destroy(Button);
                }
            }
        }
    }
    public bool CheckIfIsInInventory(GameObject item)
    {
        if (InventoryList.Contains(item)) return true;
        return false;
    }
    public bool InventoryIsOpen()
    {
        if (InventoryUI.gameObject.activeSelf == true) return true;
        return false;
    }
    public void RemoveItem(GameObject item)
    {
        if (InventoryList.Contains(item))
        {
            InventoryList.Remove(item);
        }
    }
}
