using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewConsumable : MonoBehaviour
{
 //   BaseConsumable newConsumable;
    string[] consumableSuffix = new string[5] { "potion", "sandwich", "clam", "rub", "ointment" };


    private void Start()
    {
        CreateConsumable();
     //   Debug.Log(newConsumable.ItemName);
     //   Debug.Log(newConsumable.ItemDescription);
    }
    public void CreateConsumable()
    {
      //  newConsumable = new BaseConsumable();
        // type
      //  ChooseConsumableType();
        // name
     //   newConsumable.ItemName = newConsumable.ConsumableType + " " + consumableSuffix[Random.Range(0, 5)];
        // description
      //  newConsumable.ItemDescription = "Put it in/on you.";
        // weapon ID
     //   newConsumable.ItemID = Random.Range(0, 100);
        //stats
     //   newConsumable.Strength = Random.Range(0, 3);

        //spell effect ID
     //   Random.Range(0, 17);
    }

    void ChooseConsumableType()
    {
        int rndTemp = Random.Range(1, 5);
        if (rndTemp == 1)
        {
      //      newConsumable.ConsumableType = BaseConsumable.ConsumableTypes.Hp ;
        }
        else if (rndTemp == 2)
        {
      //      newConsumable.ConsumableType = BaseConsumable.ConsumableTypes.Intellect;
        }
        else if (rndTemp == 3)
        {
     //       newConsumable.ConsumableType = BaseConsumable.ConsumableTypes.Luck;
        }
        else if (rndTemp == 4)
        {
      //      newConsumable.ConsumableType = BaseConsumable.ConsumableTypes.Strenght;
        }
    }
}
