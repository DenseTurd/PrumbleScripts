using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAllocationModule
{
    string[] statNames = new string[3] { "Hp", "Strength", "Intellect" };
    string[] statDescriptions = new string[3] { "Healths", "Henchness", "Magics"};
    bool[] statSelections = new bool[3];
    public int[] pointsToAllocate = new int[3]; //starting stat val for chosen class. use to modify
    int[] baseStatPoints = new int[3]; //starting stat val for chosen class
    int avaliablePoints = 1;
    public bool didRunOnce = false;

    public void DisplayStatAllocationModule()
    {
        if (!didRunOnce)
        {
            RetrieveBaseStatPoints();
            didRunOnce = true;
        }  
      DisplayStatIncreaseDecreaseButtons();
    }

 

    void DisplayStatIncreaseDecreaseButtons()
    {
        for (int i = 0; i < pointsToAllocate.Length; i++)
        {
            if (avaliablePoints > 0)
            {
                if (GUI.Button(new Rect(200, 60 * i + 10, 50, 50), "+"))
                {   
                    pointsToAllocate[i] += 1;
                    --avaliablePoints;
                }
            }
            
            if (pointsToAllocate[i] > (baseStatPoints[i] -1))
            {
                if (GUI.Button(new Rect(260, 60 * i + 10, 50, 50), "-"))
                {
                    pointsToAllocate[i] -= 1;
                    ++avaliablePoints;
                }
            }
           
        }
    }

    void RetrieveBaseStatPoints()
    {
        BaseCharacterClass ccClass = GameInfo.PlayerClass;
        pointsToAllocate[0] = ccClass.Hp;
        baseStatPoints[0] = ccClass.Hp;
        pointsToAllocate[1] = ccClass.Strength;
        baseStatPoints[1] = ccClass.Strength;
        pointsToAllocate[2] = ccClass.Intellect;
        baseStatPoints[2] = ccClass.Intellect;
    }
}
