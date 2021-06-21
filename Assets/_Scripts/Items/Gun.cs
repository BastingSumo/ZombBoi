using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Gun : Item
{
    [Header("Gun stuff")]
    public GameObject bullet;

    public float Damage = 5;
    public float bulletVelocity = 5;
    public float FireRate = 1;
    public float ReloadTime = 4;
    public float MagazineSize = 6;
    public float AmmoInGun = 6;

    [SerializeField] SpriteRenderer HandsRight;
    [SerializeField] SpriteRenderer HandsLeft;
    GameObject player;
    PlayerCombat playerCombat;

    [SerializeField] Transform BulletSpawnLocation;
    [SerializeField] Light2D GunFlash;

    public virtual float GetAmmoInGun { get => AmmoInGun; }

    public override void Start()
    {
        base.Start();
        Hands(false);
        GunFlash.enabled = false;
    }
    public virtual void SpawnBullet()
    {
        StartCoroutine(EnableGunFlash());
        AmmoInGun--;
        Bullet bulletTemp = Instantiate(bullet, BulletSpawnLocation.position, BulletSpawnLocation.rotation).GetComponent<Bullet>();
        bulletTemp.SetDamage = Damage;
        bulletTemp.SetVelocity = bulletVelocity;
    }
    public IEnumerator EnableGunFlash()
    {
        GunFlash.enabled = true;
        yield return new WaitForSeconds(.1f);
        GunFlash.enabled = false;
        StopCoroutine(EnableGunFlash());
    }
    public virtual void Reload()
    {
        AmmoInGun = MagazineSize;
    }
    public override void Use(GameObject item)
    {
        player = GameManager.Instance.GetCurrentPlayerObject;
        if (player != null)
        {
            base.Use(item);
            playerCombat = player.GetComponent<PlayerCombat>();
            if (playerCombat.EquippedWeapon != null) playerCombat.EquippedWeapon.SetActive(false);
            gameObject.SetActive(true);
            playerCombat.EquippedWeapon = gameObject;
            if (playerCombat.EquippedWeapon == gameObject)
            {
                Hands(true);
            }
            else
            {
                Hands(false);
            }
            playerCombat.EquippedWeapon.transform.parent = player.transform;
        }
    }
    public override void Drop(GameObject item)
    {
        base.Drop(item);
        playerCombat.EquippedWeapon = null;
        gameObject.transform.parent = null;
        Hands(false);
    }
    public void Hands(bool boolean)
    {
       if (HandsRight != null) HandsRight.gameObject.SetActive(boolean);
       if (HandsLeft != null) HandsLeft.gameObject.SetActive(boolean);
    }
    public void SetHandsOrderLayer(int SortingOrder)
    {
        if(HandsRight != null) HandsRight.sortingOrder = SortingOrder;
        if (HandsLeft != null) HandsLeft.sortingOrder = SortingOrder;
    }
}
