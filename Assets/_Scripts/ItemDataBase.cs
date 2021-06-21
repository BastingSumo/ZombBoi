using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class ItemDataBase
{
    public enum item
    {
        Empty,
        Pistol,
        BulletProofVest,

    }

    public enum Modifier
    {
        Damage,
        Armor,

    }

    public static Dictionary<item, ItemData> ItemData = new Dictionary<item, ItemData>()
    {
        {item.Empty, new ItemData("")},

        {item.Pistol, new ItemData("Pistol", new Dictionary<Modifier, float>()
            {
                {Modifier.Damage, 1.5f}
            }
        )},

        {item.BulletProofVest, new ItemData("BulletProofVest", new Dictionary<Modifier, float>()
            {
                {Modifier.Armor, 5f}
            }
        )}
    };


}
