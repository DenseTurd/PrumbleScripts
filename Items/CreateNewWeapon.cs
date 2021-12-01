using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWeapon : MonoBehaviour
{
  // BaseWeapon newWeapon;
    string[] weapSuffix = new string[5] { "'pon", "abus", "yamom", "cunt", "berk" };


    private void Start()
    {
        CreateWeapon();
     //   Debug.Log(newWeapon.ItemName);
    //    Debug.Log(newWeapon.ItemDescription);
    }
    public void CreateWeapon()
    {
     //   newWeapon = new BaseWeapon();

        // name
     //   newWeapon.ItemName = "Weap" + weapSuffix[Random.Range(0, 5)];
        // description
     //   newWeapon.ItemDescription = "Its a Ting.";
        // weapon ID
     //   newWeapon.ItemID = Random.Range(0, 100);
        //stats
    //    newWeapon.Strength = Random.Range(0, 3);
        // type
    //    ChooseWeaponType();
        //spell effect ID
    //    Random.Range(0, 17);
    }

    void ChooseWeaponType()
    {
        int rndTemp = Random.Range(1, 4);
        if (rndTemp == 1)
        {
     //       newWeapon.WeaponType = BaseWeapon.WeaponTypes.Stick;
        }
        else if (rndTemp == 2)
        {
     //       newWeapon.WeaponType = BaseWeapon.WeaponTypes.Whip;
        }
        else if (rndTemp == 3)
        {
     //       newWeapon.WeaponType = BaseWeapon.WeaponTypes.Chain;
        }
    }
}
