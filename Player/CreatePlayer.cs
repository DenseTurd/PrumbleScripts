using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    BasePlayer newPlayer;
    bool isMage;
    bool isWarrior;

    string playerName = "Enter namwe";

    void Start()
    {
        newPlayer = new BasePlayer();
    }

    
    void OnGUI()
    {
        playerName = GUILayout.TextArea(playerName, 15);
        isMage = GUILayout.Toggle(isMage, "Mage");
        isWarrior = GUILayout.Toggle(isWarrior, "Warrior");
        if (GUILayout.Button("Create"))
        {
            if (isMage)
            {
                newPlayer.PlayerClass = new BaseMageClass();
            }
            else if (isWarrior)
            {
                newPlayer.PlayerClass = new BaseWarriorClass();
            }
            CreateNewPlayer();

            StoreNewPlayerInfo();
            SaveInfo.SaveAllInfo();
        }
        if (GUILayout.Button("Load"))
        {
            Debug.Log("Loading");
        }
    }

    void StoreNewPlayerInfo()
    {
       GameInfo.PlayerName = newPlayer.PlayerName;
       GameInfo.PlayerLevel = newPlayer.Playerlevel;
       GameInfo.PlayerMaxHp =  newPlayer.PlayerHp;
       GameInfo.PlayerIntellect = newPlayer.PlayerIntellect;
       GameInfo.PlayerStrength =  newPlayer.PlayerStrength;
       GameInfo.Aioes = newPlayer.Aioes;
       
    }

    void CreateNewPlayer()
    {
        newPlayer.PlayerName = playerName;
        newPlayer.Playerlevel = 0;
        newPlayer.PlayerHp = newPlayer.PlayerClass.Hp;
        newPlayer.PlayerIntellect = newPlayer.PlayerClass.Intellect;
        newPlayer.PlayerStrength = newPlayer.PlayerClass.Strength;
        newPlayer.Aioes = newPlayer.PlayerClass.Aioes;


        Debug.Log("Name " + newPlayer.PlayerName);
        Debug.Log("Class " + newPlayer.PlayerClass.CharacterClassName);
        Debug.Log("Level " + newPlayer.Playerlevel);
        Debug.Log("Hp " + newPlayer.PlayerHp);
        Debug.Log("Intellect " + newPlayer.PlayerIntellect);
        Debug.Log("Strength " + newPlayer.PlayerStrength);
        Debug.Log("Aioes " + newPlayer.Aioes);

    }
}
