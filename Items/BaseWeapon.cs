using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseWeapon : BaseItem
{
    public enum WeaponTypes
    {
        Stick,
        Whip,
        Chain
    }

    public WeaponTypes WeaponType { get; set; }

    public int SpellEffectID { get; set; }

   
}
