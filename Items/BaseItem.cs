using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem 
{
   public string ItemName { get; set; }
   public string ItemDescription { get; set; }
    public int Hp { get; set; }
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int ItemID { get; set; }

    public enum ItemTypes
    {
        Equipment,
        Weapon,
        Armor,
        Consumable,
        Misc
    }

    public ItemTypes ItemType { get; set; }

    public BaseItem()
    {

    }
    public BaseItem(Dictionary<string, string> itemDictionary)
    {
        ItemName = itemDictionary["itemName"];
        ItemID = int.Parse(itemDictionary["itemID"]);
        ItemType = (ItemTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), (itemDictionary["itemEnum"]));
    }
}
