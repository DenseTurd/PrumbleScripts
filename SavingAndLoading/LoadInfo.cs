using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInfo : MonoBehaviour
{
   public static void LoadAllInfo()
    {
        PlayerPrefs.GetString("PlayerName");
        PlayerPrefs.GetInt("playerLevel");
        PlayerPrefs.GetInt("playerHp");
        PlayerPrefs.GetInt("playerStrength");
        PlayerPrefs.GetInt("playerIntellect");
        PlayerPrefs.GetInt("Aioes");

        if (PlayerPrefs.GetString("Equipment1") != null)
        {
            GameInfo.Equipment1 = (BaseEquipment) PPSerialization.Load("Equipment1");
        }

        Debug.Log("Loaded!");
    }
}
