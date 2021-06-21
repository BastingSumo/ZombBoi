using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    [Header("General Item Stuff")]
    [SerializeField] string itemName;
    [SerializeField] float Weight;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] SpriteRenderer InteractionSprite;
    BoxCollider2D boxCollider;
    [SerializeField] int Value = 1;
    public virtual SpriteRenderer GetSpriteRenderer { get => sprite; }
    public string GetitemName { get => itemName; }
    public SpriteRenderer GetInteractionSprite { get => InteractionSprite; }
    public int GetValue { get => Value; }

    public virtual void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        InteractionSprite.gameObject.SetActive(false);
    }
    public virtual void EnableDisableInteractionSprite(bool boolean)
    {
        InteractionSprite.gameObject.SetActive(boolean);
    }
    public virtual void Use(GameObject item)
    {
        boxCollider.enabled = false;
    }
    public virtual void Drop(GameObject item)
    {
        boxCollider.enabled = true;
    }
}
