using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapons")]
public class WeaponObject : ItemObject
{
    public float atkMultiplier;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
