using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCalculations
{
    public BattleGUI battleGUIScript;
    public void AttemptAbility(CombatData combatData)
    {
        if (GameInfo.PlayerEnergy > combatData.usedAbility.AbilityCost)
        {
            GameInfo.PlayerEnergy -= combatData.usedAbility.AbilityCost;
        }
        else
        {
            Dialogue notEnoughEnergyDialogue = new Dialogue();
            notEnoughEnergyDialogue.sentences = new string[1] { "Not enough energy." };
            battleGUIScript.UpdateLog(notEnoughEnergyDialogue);
            Debug.Log("Not enough energy");
            combatData.usedAbility = null;
            return;
        }
    }
    public void CalculatePlayerAbilityDamage(CombatData combatData)
    {
        float damage = combatData.usedAbility.AbilityPower;
        damage = CalculateStatMultiplier(damage, combatData.usedAbility.AbilityStatMultiplier);
        // abilityDamageModifyer += weapon modifyer
        // abilityDamageModifyer += status effect modifyer
        damage = CalculateCrit(combatData, damage, combatData.usedAbility.AbilityCritChance, combatData.usedAbility.AbilityCritMultiplier);
        // abilityDamageModifyer -= enemy armor
        damage = CalculateVariance(damage, combatData.usedAbility.AbilityVariance);
        combatData.abilityDamage = Mathf.RoundToInt(damage);
        DamageEnemy(combatData);
    }
    public void CalculateEnemyAbilityDamage(CombatData combatData)
    {
        float damage = combatData.usedAbility.AbilityPower;
        damage = CalculateStatMultiplier(damage, combatData.usedAbility.AbilityStatMultiplier);
        // abilityDamageModifyer += weapon modifyer
        // abilityDamageModifyer += status effect modifyer
        damage = CalculateCrit(combatData, damage, combatData.usedAbility.AbilityCritChance, combatData.usedAbility.AbilityCritMultiplier);
        // abilityDamageModifyer -= enemy armor
        damage = CalculateVariance(damage, combatData.usedAbility.AbilityVariance);
        combatData.abilityDamage = Mathf.RoundToInt(damage);
        GameInfo.PlayerCurrentHp -= (int)combatData.abilityDamage;
        Debug.Log("Enemy used " + combatData.usedAbility.AbilityName + " for " + combatData.abilityDamage + " damage.");
    }
    float CalculateStatMultiplier(float damage, string statMultiplier)
    {
        int Multiplier = 0;
        if (statMultiplier == "PlayerStrength")
        {
            Multiplier = GameInfo.PlayerStrength;
        }
        else if (statMultiplier == "PlayerIntellect")
        {
            Multiplier = GameInfo.PlayerIntellect;
        }
        damage *= Multiplier;
        return damage;
    }
    public void CalculateStatusEffectDamage(CombatData combatData)
    {
        if (combatData.enemyStatusEffects != null)
        {
            for (int i = 0; i < combatData.enemyStatusEffects.Count; i++)
            {
                if (combatData.enemyStatusEffects[i].RemainingDuration > 0)
                {
                    float damage = combatData.enemyStatusEffects[i].StatusPower;
                    damage = CalculateStatMultiplier(damage, combatData.usedAbility.AbilityStatMultiplier);
                    damage = CalculateCrit(combatData, damage, combatData.enemyStatusEffects[i].StatusCritChance, combatData.enemyStatusEffects[i].StatusCritMultiplier);
                    damage = CalculateVariance(damage, combatData.enemyStatusEffects[i].StatusVariance);
                    combatData.statusDamage = Mathf.RoundToInt(damage);
                    battleGUIScript.CreateCausedStatusDamageDialogue(combatData.enemy.EnemyName, (int)combatData.statusDamage, combatData.enemyStatusEffects[i].StatusName);
                    StatusDamageEnemy(combatData);
                    combatData.enemyStatusEffects[i].RemainingDuration -= 1;
                }
                else
                {
                    combatData.enemyStatusEffects.Remove(combatData.enemyStatusEffects[i]);
                }
            }
        }
    }
    public void CheckAbilityForStatusEffect(CombatData combatData)
    {

        if (combatData.usedAbility.AbilityStatusEffects.Count != 0)
        {
            for (int i = 0; i < combatData.usedAbility.AbilityStatusEffects.Count; i++)
            {
                combatData.usedAbility.AbilityStatusEffects[i].RemainingDuration = combatData.usedAbility.AbilityStatusEffects[i].StatusDuration;
                combatData.enemyStatusEffects.Add(combatData.usedAbility.AbilityStatusEffects[i]);
            }

        }
        else
        {
           
        }

    }
    float CalculateCrit(CombatData combatData, float damage, float critChance, float critMultiplier)
    {
        if(Random.Range(0f,1f) < critChance)
        {
            damage *= critMultiplier;
            combatData.crit = true;
            Debug.Log("Did a crit on him");
        }
        else
        {
            combatData.crit = false;
        }
        return damage;
    }
    float CalculateVariance(float damage, float variance)
    {
        damage *= 1 + Random.Range(-variance, variance);
        return damage;
    }
    void DamageEnemy(CombatData combatData)
    {
        combatData.enemy.EnemyCurrentHp -= (int) combatData.abilityDamage;
        Debug.Log("Ability damage: " + combatData.abilityDamage);
        CombatStateMachine.playerCompletedTurn = true;
        if (combatData.enemy.EnemyCurrentHp <= 0)
        {
            combatData.enemy.EnemyCurrentHp = 0;
            CombatStateMachine.win = true;
        }
    }
    void StatusDamageEnemy(CombatData combatData)
    {
         combatData.enemy.EnemyCurrentHp -= (int)combatData.statusDamage;
                Debug.Log("Status damage: " + combatData.statusDamage);
        if (combatData.enemy.EnemyCurrentHp <= 0)
        {
            combatData.enemy.EnemyCurrentHp = 0;
            CombatStateMachine.win = true;
        }
       
    }
}

