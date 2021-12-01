using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfo : MonoBehaviour
{
    public static void SaveAllInfo()
    {
        PlayerPrefs.SetInt("isMale", GameInfo.isMale);
        PlayerPrefs.SetString("PlayerName", GameInfo.PlayerName);
        PlayerPrefs.SetString("PlayerBio", GameInfo.PlayerBio);
        PlayerPrefs.SetInt("playerLevel", GameInfo.PlayerLevel);
        PlayerPrefs.SetInt("playerHp", GameInfo.PlayerMaxHp);
        PlayerPrefs.SetInt("playerCurrentHp", GameInfo.PlayerCurrentHp);
        PlayerPrefs.SetInt("playerStrength", GameInfo.PlayerStrength);
        PlayerPrefs.SetInt("playerIntellect", GameInfo.PlayerIntellect);
        PlayerPrefs.SetInt("Aioes", GameInfo.Aioes);

        if (GameInfo.Equipment1 != null)
        {
            PPSerialization.Save("Equipment1", GameInfo.Equipment1);
        }

        Debug.Log("Saved all");
    }
}
