using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateEnemyChoice
{
    BaseAbility enemyAbility;
  public BaseAbility EnemyChoice(BaseEnemy enemy)
  {
        int i = Random.Range(0, enemy.EnemyClass.EnemyAbilities.Count);
        enemyAbility = enemy.EnemyClass.EnemyAbilities[i];
        CombatStateMachine.enemyCompletedTurn = true;
        return enemyAbility;
        
  }
}
