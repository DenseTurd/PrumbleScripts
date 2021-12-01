using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewArmor : MonoBehaviour
{
 //  BaseArmor newArmor;
    string[] armorSuffix = new string[5] { "piece", "cover", "sheath", "flap", "garm" };


    private void Start()
    {
      //  CreateArmor();
    //    Debug.Log(newArmor.ItemName);
   //     Debug.Log(newArmor.ItemDescription);
    }
   // public void CreateArmor()
  //  {
  //      newArmor = new BaseArmor();
        // type
  //      ChooseArmorType();
        // name
 //       newArmor.ItemName = newArmor.ArmorType + armorSuffix[Random.Range(0, 5)];
        // description
 //       newArmor.ItemDescription = "Covers your ting.";
        // weapon ID
 //       newArmor.ItemID = Random.Range(0, 100);
        //stats
 //       newArmor.Strength = Random.Range(0, 3);
       
        //spell effect ID
 //       Random.Range(0, 17);
  //  }

    void ChooseArmorType()
    {
        int rndTemp = Random.Range(1, 5);
        if (rndTemp == 1)
        {
    //        newArmor.ArmorType = BaseArmor.ArmorTypes.Head;
        }
        else if (rndTemp == 2)
        {
    //        newArmor.ArmorType = BaseArmor.ArmorTypes.Chest;
        }
        else if (rndTemp == 3)
        {
   //         newArmor.ArmorType = BaseArmor.ArmorTypes.Legs;
        }
        else if (rndTemp == 4)
        {
   //         newArmor.ArmorType = BaseArmor.ArmorTypes.Accessory;
        }
    }
}
