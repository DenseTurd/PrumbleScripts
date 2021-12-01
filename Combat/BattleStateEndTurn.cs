using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateEndTurn
{
   public void EndTurn(CombatStateMachine combatStateMachine)
    {
        combatStateMachine.totalTurnCount += 1;
        CombatStateMachine.playerCompletedTurn = false;
        CombatStateMachine.enemyCompletedTurn = false;
        CombatStateMachine.allyCombatData.usedAbility = null;
        CombatStateMachine.enemyCombatData.usedAbility = null;
        GameInfo.PlayerEnergy += 0.2f;
        if (GameInfo.PlayerEnergy > 1f)
        {
            GameInfo.PlayerEnergy = 1f;
        }

        Debug.Log("Turn " + combatStateMachine.totalTurnCount + " complete.");
    }
}
