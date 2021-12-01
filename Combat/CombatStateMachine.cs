using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : MonoBehaviour
{
    BattleStateStart battleStateStartScript = new BattleStateStart();
    BattleStateEnemyChoice battleStateEnemyChoiceScript = new BattleStateEnemyChoice();
    BattleCalculations battleCalcScript = new BattleCalculations();
    BattleStateEndTurn battleStateEndTurnScript = new BattleStateEndTurn();
    BattleStateWin battleStateWinScript = new BattleStateWin();
    public int totalTurnCount;
    public static bool playerCompletedTurn;
    public static bool enemyCompletedTurn;
    public static bool win;
    public static bool awaitingInput;
    public static BattleGUI battleGUIScript;

    public static CombatData allyCombatData = new CombatData();
    public static CombatData enemyCombatData = new CombatData();
    public enum battleStates
    {
        start,
        playerChoice,
        playerCalculationsAbility,
        playerCalculationsStatusEffects,
        enemyChoice,
        enemyCalculationsAbility,
        endTurn,
        lose,
        win
    }
    public static battleStates currentState;

    void Start()
    {
        currentState = battleStates.start;
    }
    public void NextTing()
    {
        if (awaitingInput)
        {
            awaitingInput = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextTing();
        }
        switch (currentState)
        {
            case (battleStates.start):
                GameInfo.IsInCombat = true;
                battleCalcScript.battleGUIScript = battleGUIScript;
                battleStateStartScript.PrepBattle();
                allyCombatData.enemy = battleStateStartScript.CreateNewEnemy();
                enemyCombatData.enemy = allyCombatData.enemy;
                battleGUIScript.UpdateGUI(allyCombatData);
                awaitingInput = true;
                TurnTaker();
                break;

            case (battleStates.playerChoice):
                if (allyCombatData.usedAbility != null)
                {
                    battleCalcScript.AttemptAbility(allyCombatData);
                    if (allyCombatData.usedAbility != null)
                    {
                        battleGUIScript.CreateActionSelectedDialogue(allyCombatData, GameInfo.PlayerName);
                        currentState = battleStates.playerCalculationsAbility;
                        awaitingInput = true;
                    }
                }
                break;

            case (battleStates.playerCalculationsAbility):
                if (!awaitingInput)
                {
                    awaitingInput = true;
                    battleCalcScript.CalculatePlayerAbilityDamage(allyCombatData);
                    battleGUIScript.CreateCausedDamageDialogue(allyCombatData.enemy.EnemyName, (int) allyCombatData.abilityDamage, allyCombatData.crit);
                    battleGUIScript.UpdateGUI(allyCombatData);
                    currentState = battleStates.playerCalculationsStatusEffects;
                }
                break;

            case (battleStates.playerCalculationsStatusEffects):
                if (!awaitingInput)
                {
                    awaitingInput = true;
                    battleCalcScript.CheckAbilityForStatusEffect(allyCombatData);
                    battleCalcScript.CalculateStatusEffectDamage(allyCombatData);
                    battleGUIScript.UpdateGUI(allyCombatData);
                    TurnTaker();
                }
                break;

            case (battleStates.enemyChoice):
                if (!awaitingInput)
                {
                    awaitingInput = true;
                    enemyCombatData.usedAbility = battleStateEnemyChoiceScript.EnemyChoice(enemyCombatData.enemy);
                    battleGUIScript.CreateActionSelectedDialogue(enemyCombatData, enemyCombatData.enemy.EnemyName);
                    currentState = battleStates.enemyCalculationsAbility;
                }
                break;

            case (battleStates.enemyCalculationsAbility):
                if (!awaitingInput)
                {
                    battleCalcScript.CalculateEnemyAbilityDamage(enemyCombatData);
                    battleGUIScript.CreateCausedDamageDialogue(GameInfo.PlayerName, (int)enemyCombatData.abilityDamage, enemyCombatData.crit);
                    battleGUIScript.UpdateGUI(allyCombatData);
                    TurnTaker();
                }
                break;

            case (battleStates.endTurn):

                battleStateEndTurnScript.EndTurn(this);
                battleGUIScript.UpdateGUI(allyCombatData);
                TurnTaker();
                break;


            case (battleStates.win):
                GameInfo.IsInCombat = false;
                Debug.Log("winState");
                battleStateWinScript.Win(allyCombatData);
                break;

            case (battleStates.lose):

                break;
        }
    }

    void TurnTaker()
    {
            if (!win)
            {
                if (playerCompletedTurn && !enemyCompletedTurn)
                {
                    currentState = battleStates.enemyChoice;
                }
                if (!playerCompletedTurn && enemyCompletedTurn)
                {
                    currentState = battleStates.playerChoice;
                }
                if (playerCompletedTurn && enemyCompletedTurn)
                {
                    currentState = battleStates.endTurn;
                }
                if (!playerCompletedTurn && !enemyCompletedTurn)
                {
                    if (battleStateStartScript.whoGoesFirst == 0)
                    {
                        currentState = battleStates.playerChoice;
                    }
                    else
                    {
                        currentState = battleStates.enemyChoice;
                    }
                }
            }
            if (win)
            {
                currentState = battleStates.win;
            }
    }

    
}
