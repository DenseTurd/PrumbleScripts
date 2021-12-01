using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatData 
{
    public BaseAbility usedAbility;
    public BaseEnemy enemy;
    public int abilityIndex;
    public float abilityDamage;
    public float statusDamage;
    public bool crit;
    public List<BaseStatusEffect> enemyStatusEffects = new List<BaseStatusEffect>();
}
