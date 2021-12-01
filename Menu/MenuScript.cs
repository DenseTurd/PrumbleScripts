using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public ScrollRect inventoryScrollRect;
    public GameObject inventoryScrollListButton;
    public TMP_Text inventoryDescription;
    public GameObject menuPanel;
    public GameObject characterPanel;
    public GameObject InventoryPanel;
    public GameObject StatPanel;
    public static bool paused = false;

    public void PopulateInventoryScrollRect()
    {
        foreach(Transform child in inventoryScrollRect.content)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < GameInfo.PlayerInventory.container.Count; i++)
        {
            GameObject item = Instantiate(inventoryScrollListButton) as GameObject;
            InventoryScrollListButton inventoryScrollListButtonScript = item.GetComponent<InventoryScrollListButton>();
            inventoryScrollListButtonScript.itemNameText.text = (GameInfo.PlayerInventory.container[i].item.itemName);
            inventoryScrollListButtonScript.inventoryListIndex = i;
            inventoryScrollListButtonScript.menuScript = this;
            item.transform.SetParent(inventoryScrollRect.content, false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!paused)
            {
                menuPanel.SetActive(true);
                paused = true;
                Time.timeScale = 0;
                return;
            }
            if (paused)
            {
                if (!menuPanel.activeSelf)
                {
                    menuPanel.SetActive(true);
                    characterPanel.SetActive(false);
                    InventoryPanel.SetActive(false);
                    StatPanel.SetActive(false);
                    return;
                }
                else if (menuPanel.activeSelf)
                {
                    Time.timeScale = 1;
                    menuPanel.SetActive(false);
                    paused = false;
                    return;
                }
            }
        }
            
        
    }
    public void ShowDescription(InventoryScrollListButton item)
    {
        int inventoryID = item.inventoryListIndex;
        inventoryDescription.text = GameInfo.PlayerInventory.container[inventoryID].item.description;

    }
    public void ClearDescription()
    {
        inventoryDescription.text = "";
    }
}
