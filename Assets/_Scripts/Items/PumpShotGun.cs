using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpShotGun : Gun
{
    public override void SpawnBullet()
    {
        base.StartCoroutine(EnableGunFlash());
        AmmoInGun--;
        GameObject[] Array = new GameObject[3];
        Array[0] = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        Array[1] = Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z - 5));
        Array[2] = Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + 5));
        for (int i = 0; i < Array.Length; i++)
        {
            Bullet bullet = Array[i].GetComponent<Bullet>();
            bullet.SetDamage = Damage;
            bullet.SetVelocity = bulletVelocity;
        }
    }
}
