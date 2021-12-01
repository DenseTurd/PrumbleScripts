using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class ItemDatabasing : MonoBehaviour
{
    public TextAsset itemInventoryxml;
    public static List<BaseItem> inventoryItems = new List<BaseItem>();
    List<Dictionary<string, string>> inventoryItemsDictionary = new List<Dictionary<string, string>>();
    Dictionary<string, string> itemDictionary;

    private void Awake()
    {
        ReadItemDatabase();
        for (int i = 0; i < inventoryItemsDictionary.Count; i++)
        {
          
            inventoryItems.Add(new BaseItem(inventoryItemsDictionary[i]));
        }
    }
    public void ReadItemDatabase()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(itemInventoryxml.text);
        XmlNodeList itemList = xmlDocument.GetElementsByTagName("Item");

        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            itemDictionary = new Dictionary<string, string>();

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "itemName":
                        itemDictionary.Add("itemName", content.InnerText);
                        break;
                    case "itemID":
                        itemDictionary.Add("itemID", content.InnerText);
                        break;
                    case "itemEnum":
                        itemDictionary.Add("itemEnum", content.InnerText);
                        break;
                }
            }

            inventoryItemsDictionary.Add(itemDictionary);

        }



    }

}
