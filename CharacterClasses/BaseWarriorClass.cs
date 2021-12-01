using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarriorClass : BaseCharacterClass
{
   public BaseWarriorClass()
    {
        CharacterClassName = "Warrior" ;
        CharacterClassDescription = "Hench guy, does hench tings.";
        Hp = 10;
        CurrentHp = Hp;
        Strength = 10;
        Intellect = 4;
        Aioes = 1;
        PlayerAbilities.Add(new BopAbility());
        PlayerAbilities.Add(new BoopAbility());
        PlayerAbilities.Add(new DigOuterThighAbility());
        PlayerAbilities.Add(new BopAbility());
        PlayerAbilities.Add(new BoopAbility());
        PlayerAbilities.Add(new DigOuterThighAbility());
        PlayerAbilities.Add(new BopAbility());
        PlayerAbilities.Add(new BoopAbility());
        PlayerAbilities.Add(new DigOuterThighAbility());
        PlayerAbilities.Add(new BopAbility());
        PlayerAbilities.Add(new BoopAbility());
        PlayerAbilities.Add(new DigOuterThighAbility());
        PlayerAbilities.Add(new BopAbility());
        PlayerAbilities.Add(new BoopAbility());
        PlayerAbilities.Add(new DigOuterThighAbility());
        PlayerAbilities.Add(new BopAbility());
        PlayerAbilities.Add(new BoopAbility());
        PlayerAbilities.Add(new DigOuterThighAbility());
    }
}
