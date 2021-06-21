using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestArmor : Armor
{
    public override void Use(GameObject item)
    {
        base.Use(item);
        GameObject player = GameManager.Instance.GetCurrentPlayerObject;
        if (player != null)
        {
            PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
            base.Use(item);
            if (playerCombat.EquippedChestArmor != null) playerCombat.EquippedChestArmor.SetActive(false);
            gameObject.SetActive(true);
            playerCombat.EquippedChestArmor = gameObject;
            playerCombat.EquippedChestArmor.transform.parent = player.transform;
            GetSpriteRenderer.sortingOrder = 1;
        }
    }
}
