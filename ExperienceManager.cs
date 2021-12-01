using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExperienceManager
{
   public static void AddExperience(int xpGain)
   {
        GameInfo.CurrentXP += xpGain;

        if (GameInfo.CurrentXP >= GameInfo.RequiredXP)
        {
            LevelUp();
        }

        Debug.Log("Level " + GameInfo.PlayerLevel);
        Debug.Log("CurrentXP " + GameInfo.CurrentXP);
        Debug.Log("RequiredXP " + GameInfo.RequiredXP);

   }

    public static void LevelUp()
    {
        int temp = GameInfo.CurrentXP - GameInfo.RequiredXP;
        GameInfo.CurrentXP = temp;
        GameInfo.PlayerLevel += 1;
        // stat points
        // determine required xp
        DetermineReqiredXP();
    }

    public static void StatIncrease()
    {
        return; // sort it out
    }

    public static void DetermineReqiredXP()
    {
        int temp = (GameInfo.PlayerLevel) + (Mathf.RoundToInt(GameInfo.PlayerLevel / 10)) + 1;
        GameInfo.RequiredXP += temp;
    }
}
