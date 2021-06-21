using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    [Header("Armor Stats")]
    [SerializeField] float DamageReduction;

    [Header("Armor Sprites")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite ArmorFaceUp;
    [SerializeField] Sprite ArmorFaceDown;
    [SerializeField] Sprite ArmorFaceLeftorRight;

    public void Animate()
    {
        if (InputManager.isPressingUp()) spriteRenderer.sprite = ArmorFaceUp;
        if (InputManager.isPressingDown()) spriteRenderer.sprite = ArmorFaceDown;
        if (InputManager.isPressingRight() || InputManager.isPressingLeft()) spriteRenderer.sprite = ArmorFaceLeftorRight;
    }
    public override void Drop(GameObject item)
    {
        GameObject player = GameManager.Instance.GetCurrentPlayerObject;
        if (player != null)
        {
            base.Drop(item);
            player.GetComponent<PlayerCombat>().UnequipArmor(gameObject);
        }
    }
    public float GetDamageReduction { get => DamageReduction; }
}
