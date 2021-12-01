using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass 
{
    
    public string CharacterClassName { get; set; }
    public string CharacterClassDescription { get; set; }
    public int Hp { get; set; }
    public int CurrentHp { get; set; }
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Aioes { get; set; }

    public List<BaseAbility> PlayerAbilities = new List<BaseAbility>();

}
