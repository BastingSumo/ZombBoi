using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : Armor
{
    public override void Use(GameObject item)
    {
        GameObject player = GameManager.Instance.GetCurrentPlayerObject;
        if (player != null)
        {
            PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
            base.Use(item);
            if (playerCombat.EquippedHat != null) playerCombat.EquippedHat.SetActive(false);
            gameObject.SetActive(true);
            playerCombat.EquippedHat = gameObject;
            playerCombat.EquippedHat.transform.parent = player.transform;
            GetSpriteRenderer.sortingOrder = 1;
        }
    }
}
