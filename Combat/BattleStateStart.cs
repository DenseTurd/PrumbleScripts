using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateStart 
{
    public BaseEnemy newEnemy = new BaseEnemy();
    List<string> enemyNames = new List<string>() { "turd", "choad", "flombay", "splodge", "diminutive ", "swineapple", "greg", "special", "jaerb", "nope", "cabbage", "chikadee", "spigot", "ladel", "oare", "plump", "sedentarty", "plimb", "waffle", "qwalk", "binny" };
    public int whoGoesFirst;
    
    public void PrepBattle()
    {
        CleanSlate(); // reset static variables, empty combat data
        whoGoesFirst = ChooseWhoGoesFirst();
        GameInfo.PlayerEnergy = 1; 
    }
    public BaseEnemy CreateNewEnemy()
    {


        newEnemy.Enemylevel = Random.Range(GameInfo.PlayerLevel - 3, GameInfo.PlayerLevel + 3);
        if (newEnemy.Enemylevel <= 0)
        {
            newEnemy.Enemylevel = 1;
        }

        int speciality1 = Random.Range(1, 4);
        int speciality2 = Random.Range(1, 4);
        int speciality1Points = Mathf.RoundToInt(newEnemy.Enemylevel * 0.66f);
        int speciality2Points = Mathf.RoundToInt(newEnemy.Enemylevel * 0.33f);
        string tempName = "";

        if (Random.Range(0, 2) == 0) // Choose a random class
        {
            newEnemy.EnemyClass = new BaseEWarriorClass();
            tempName += "Warria ";
        }
        else
        {
            newEnemy.EnemyClass = new BaseEMageClass();
            tempName += "Wizza ";
        }

        newEnemy.EnemyHp = Random.Range(7, 10);
        newEnemy.EnemyStrength = Random.Range(7, 10);
        newEnemy.EnemyIntellect = Random.Range(7, 10);

        if (speciality1 == 1)
        {
            newEnemy.EnemyHp += speciality1Points;
            tempName += "large ";
        }
        else if (speciality1 == 2)
        {
            newEnemy.EnemyStrength += speciality1Points;
            tempName += "Hench ";
        }
        else if (speciality1 == 3)
        {
            newEnemy.EnemyIntellect += speciality1Points;
            tempName += "Smarty ";
        }

        if (speciality2 == 1)
        {
            newEnemy.EnemyHp += speciality2Points;
            tempName += "big ";
        }
        else if (speciality2 == 2)
        {
            newEnemy.EnemyStrength += speciality2Points;
            tempName += "buff ";
        }
        else if (speciality2 == 3)
        {
            newEnemy.EnemyIntellect += speciality2Points;
            tempName += "cleva ";
        }
        newEnemy.EnemyCurrentHp = newEnemy.EnemyHp;
        tempName += enemyNames[Random.Range(0, enemyNames.Count)];
        newEnemy.EnemyAioes = (Random.Range(newEnemy.Enemylevel - 5, newEnemy.Enemylevel + 5) +5);
        newEnemy.EnemyName = tempName;
        Debug.Log(newEnemy.EnemyName);
        return newEnemy;
    }
    int ChooseWhoGoesFirst()
    {
         whoGoesFirst = 0;
        if (Random.Range(0f, 1f) >= 0.3f)
        {
            whoGoesFirst = 0;
        }
        else
        {
            whoGoesFirst = 1;
        }
        return whoGoesFirst;
    }
    void CleanSlate()
    {
        CombatStateMachine.enemyCompletedTurn = false;
        CombatStateMachine.playerCompletedTurn = false;
        CombatStateMachine.win = false;
        CombatStateMachine.allyCombatData.usedAbility = null;
        CombatStateMachine.enemyCombatData.usedAbility = null;
        CombatStateMachine.allyCombatData = new CombatData();
        CombatStateMachine.enemyCombatData = new CombatData();
    }
}
