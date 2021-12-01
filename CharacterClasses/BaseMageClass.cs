using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMageClass : BaseCharacterClass
{
   public BaseMageClass()
    {
        CharacterClassName = "Mage" ;
        CharacterClassDescription = "Oooh, sparkles";
        Hp = 10;
        CurrentHp = Hp;
        Strength = 4;
        Intellect = 10;
        Aioes = 4;
        PlayerAbilities.Add(new MoistAbility());
    }
}
