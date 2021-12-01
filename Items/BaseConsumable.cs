using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConsumable : BaseItem
{
    public enum ConsumableTypes
    {
        Hp,
        Strenght,
        Intellect,
        Luck
    }

    public ConsumableTypes ConsumableType { get; set; }
    public int SpellEffectID { get; set; }

   
}
