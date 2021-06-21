using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Armor")]
    public GameObject EquippedChestArmor;
    Armor ChestArmorScript;
    int EquippedChestArmorLastId;
    public GameObject EquippedHat;
    Armor HatScript;
    int EquippedHatLastId;
    float DamageReduction;


    [Header("Weapon")]
    public GameObject EquippedWeapon;
    Gun gunScript;
    float fireTimer = 0;
    float reloadTimer = 0;
    Vector3 MouseWorldPostion;
    bool IsReloading = false;

    [Header("Torch")]
    public GameObject EquippedTorch;
    Torch TorchScript;

    [Header("Reload Animation")]
    [SerializeField] GameObject ReloadBar;
    [SerializeField] GameObject ReloadBarInside;

    public float GetDamageReduction { get => DamageReduction; }

    private void Update()
    {
        Weapon();
        Armor(EquippedHat, HatScript, EquippedHatLastId);
        Armor(EquippedChestArmor, ChestArmorScript, EquippedChestArmorLastId);
        ShowReloadBar();
        Torch();
    }
    void Torch()
    {
        if (EquippedTorch != null)
        {
            EquippedTorch.transform.position = gameObject.transform.position;
            TorchScript = EquippedTorch.GetComponent<Torch>();
            EquippedTorch.transform.rotation = GunFaceMouse();
        }
    }
    void Weapon()
    {
        if (EquippedWeapon != null)
        {
            EquippedWeapon.transform.position = gameObject.transform.position;
            gunScript = EquippedWeapon.GetComponent<Gun>();
            EquippedWeapon.transform.rotation = GunFaceMouse();
            if (HasAmmoInGun()) FireWeapon();
            else
            {
                IsReloading = true;
            }
            ReloadWeapon();
        }
    }
    void Armor(GameObject EquippedArmor, Armor Script, int LastArmorId)
    {
        if (EquippedArmor != null) 
        {
            EquippedArmor.transform.position = gameObject.transform.position;
            if (EquippedArmor.GetInstanceID() != LastArmorId) 
            {
                Script = EquippedArmor.GetComponent<Armor>();
                DamageReduction += Script.GetDamageReduction;
                LastArmorId = EquippedArmor.GetInstanceID();
            }
            if (Script != null) Script.Animate();
        }
    }
    void FireWeapon()
    {
        if (InputManager.isShooting() && fireTimer > gunScript.FireRate)
        {
            gunScript.SpawnBullet();
            fireTimer = 0;
        }
        else
        {
            fireTimer += 1 * Time.deltaTime;
        }
    }
    void ReloadWeapon()
    {
        if (IsReloading == false) IsReloading = InputManager.hasPressedReload();
        if (IsReloading == true)
        {
            if (reloadTimer > gunScript.ReloadTime)
            {
                Debug.Log("Reloaded");
                gunScript.Reload();
                IsReloading = false;
                reloadTimer = 0;
            }
            else
            {
                reloadTimer += 1 * Time.deltaTime;
                Debug.Log("Reloading");
            }
        }
    }
    bool HasAmmoInGun()
    {
        if (gunScript.GetAmmoInGun > 0) return true;
        return false;
    }
    Quaternion GunFaceMouse()
    {
        MouseWorldPostion = GetMousePosition();
        if (InputManager.isPressingUp())
        {
            SetSpriteandHandsLayer(-1);
            if (MouseIsRightSideofPlayer())
            {
                float direction = Mathf.Rad2Deg * Mathf.Atan(-MouseWorldPostion.y / MouseWorldPostion.x);
                return Quaternion.Euler(new Vector3(0, 180, direction));
            }
            else
            {
                float direction = Mathf.Rad2Deg * Mathf.Atan(MouseWorldPostion.y / MouseWorldPostion.x);
                return Quaternion.Euler(new Vector3(0, 0, direction));
            }
        }
        else if (!MouseIsRightSideofPlayer())
        {
            SetSpriteandHandsLayer(2);
            float direction = Mathf.Rad2Deg * Mathf.Atan(MouseWorldPostion.y / MouseWorldPostion.x);
            return Quaternion.Euler(new Vector3(0, 0, direction));
        }
        else
        {
            SetSpriteandHandsLayer(2);
            float direction = Mathf.Rad2Deg * Mathf.Atan(-MouseWorldPostion.y / MouseWorldPostion.x);
            return Quaternion.Euler(new Vector3(0, 180, direction));
        }
    }
    void SetSpriteandHandsLayer(int Layer)
    {
        if (gunScript != null)
        {
            gunScript.GetSpriteRenderer.sortingOrder = Layer;
            gunScript.SetHandsOrderLayer(Layer);
        }
        else if (TorchScript != null)
        {
            TorchScript.GetSpriteRenderer.sortingOrder = Layer;
            TorchScript.SetHandsOrderLayer(Layer);
        }
    }
    Vector2 GetMousePosition() => MouseWorldPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
    bool MouseIsRightSideofPlayer()
    {
        if (gameObject.transform.position.x > MouseWorldPostion.x + gameObject.transform.position.x) return true;
        return false;
    }
    public void UnequipArmor(GameObject armor)
    {
        armor.transform.parent = null;
        if (armor == EquippedChestArmor)
        {
            EquippedChestArmor = null;
            ChestArmorScript = null;
        }
        else if (armor == EquippedHat)
        {
            EquippedHat = null;
            HatScript = null;
        }
    }
    void ShowReloadBar()
    {
        if (IsReloading)
        {
            ReloadBarInside.transform.localScale = new Vector3(reloadTimer / gunScript.ReloadTime, ReloadBar.transform.localScale.y, ReloadBar.transform.localScale.z);
            ReloadBar.SetActive(true);
        }
        else ReloadBar.SetActive(false);
    }
}
