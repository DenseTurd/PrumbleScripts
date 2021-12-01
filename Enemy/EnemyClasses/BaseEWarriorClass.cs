using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEWarriorClass : BaseEnemyClass
{
   public BaseEWarriorClass()
    {
        EnemyClassName = "Warrior" ;
        EnemyClassDescription = "Hench guy, does hench tings.";
        EnemyHp = 10;
        EnemyCurrentHp = EnemyHp;
        EnemyStrength = 10;
        EnemyIntellect = 4;
        EnemyAioes = 1;
        EnemyAbilities.Add(new BopAbility());
        EnemyAbilities.Add(new BoopAbility());
        
    }
}
