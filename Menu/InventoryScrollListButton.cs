using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScrollListButton : MonoBehaviour
{
    public TMP_Text itemNameText;
    public int inventoryListIndex;
    public MenuScript menuScript;


    public void OnClick()
    {
        GameInfo.PlayerInventory.container[inventoryListIndex].item.Use();
        GameInfo.PlayerInventory.RemoveItem(GameInfo.PlayerInventory.container[inventoryListIndex].item);
        menuScript.PopulateInventoryScrollRect();
    }

    public void OnMouseOver()
    {
        menuScript.ShowDescription(this);
    }

}
