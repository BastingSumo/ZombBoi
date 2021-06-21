using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Item
{
    [SerializeField] SpriteRenderer HandsRight;
    [SerializeField] SpriteRenderer HandsLeft;
    GameObject player;
    PlayerCombat playerCombat;
    [SerializeField] GameObject Light;
    public override void Start()
    {
        base.Start();
        Light.SetActive(false);
        Hands(false);
    }
    public override void Use(GameObject item)
    {
        player = GameManager.Instance.GetCurrentPlayerObject;
        if (player != null)
        {
            base.Use(item);
            playerCombat = player.GetComponent<PlayerCombat>();
            if (playerCombat.EquippedTorch != null) playerCombat.EquippedTorch.SetActive(false);
            gameObject.SetActive(true);
            playerCombat.EquippedTorch = gameObject;
            if (playerCombat.EquippedTorch == gameObject)
            {
                Hands(true);
                Light.SetActive(true);
            }
            else
            {
                Light.SetActive(false);
                Hands(false);
            }
            playerCombat.EquippedTorch.transform.parent = player.transform;
        }
    }
    public override void Drop(GameObject item)
    {
        base.Drop(item);
        playerCombat.EquippedTorch = null;
        gameObject.transform.parent = null;
        Light.SetActive(false);
        Hands(false);
    }
    public void Hands(bool boolean)
    {
        if (HandsRight != null) HandsRight.gameObject.SetActive(boolean);
        if (HandsLeft != null) HandsLeft.gameObject.SetActive(boolean);
    }
    public void SetHandsOrderLayer(int SortingOrder)
    {
        if (HandsRight != null) HandsRight.sortingOrder = SortingOrder;
        if (HandsLeft != null) HandsLeft.sortingOrder = SortingOrder;
    }
}
