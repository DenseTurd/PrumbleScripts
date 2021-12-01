using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _quantity)
    {
        bool hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item)
            {
                container[i].AddQuantity(_quantity);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            container.Add(new InventorySlot(_item, _quantity));
        }
    }
    public void RemoveItem(ItemObject _item)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item)
            {
                if(container[i].quantity > 1)
                {
                    container[i].RemoveQuantity(1);
                    break;
                }
                else
                {
                    container.Remove(container[i]);
                }

            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int quantity;
    public InventorySlot(ItemObject _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }
    public void AddQuantity(int value)
    {
        quantity += value;
    }
    public void RemoveQuantity(int value)
    {
        quantity -= value;
    }
}
