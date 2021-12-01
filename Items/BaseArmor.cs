using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArmor : BaseItem
{
    public enum ArmorTypes
    {
        Head,
        Chest,
        Legs,
        Accessory
    }

    public ArmorTypes ArmorType { get; set; }

    public int SpellEffectID { get; set; }
   
}
