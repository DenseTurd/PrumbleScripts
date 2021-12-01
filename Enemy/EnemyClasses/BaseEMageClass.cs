using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEMageClass : BaseEnemyClass
{
   public BaseEMageClass()
    {
        EnemyClassName = "Mage" ;
        EnemyClassDescription = "Oooh, sparkles";
        EnemyHp = 10;
        EnemyCurrentHp = EnemyHp;
        EnemyStrength = 4;
        EnemyIntellect = 10;
        EnemyAioes = 4;
        EnemyAbilities.Add(new MoistAbility());
        EnemyAbilities.Add(new BopAbility());
    }
}
