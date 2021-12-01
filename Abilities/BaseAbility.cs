using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseAbility 
{
    public string AbilityName { get; set; }
    public string AbilityDescription { get; set; }
    public float AbilityPower { get; set; }
    public float AbilityCost { get; set; }
    public string AbilityStatMultiplier { get; set; }
    public float AbilityCritChance { get; set; }
    public float AbilityCritMultiplier { get; set; }
    public float AbilityVariance { get; set; }

    public List<BaseStatusEffect> AbilityStatusEffects = new List<BaseStatusEffect>();  
}
