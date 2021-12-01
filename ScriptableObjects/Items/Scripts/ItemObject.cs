using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject, IUseable
{
    public GameObject prefab;
    public ItemType type;
    public string itemName;
    [TextArea(15,20)]
    public string description;

    public virtual void Use()
    {
        Debug.Log("Base use");
    }
}
