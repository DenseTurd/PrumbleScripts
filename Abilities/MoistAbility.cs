[System.Serializable]
public class MoistAbility : BaseAbility
{
   public MoistAbility()
    {
        AbilityName = "Moist";
        AbilityDescription = "You like that word? ;)";
        AbilityPower = 0.2f;
        AbilityCost = 0.2f;
        AbilityStatMultiplier = "PlayerIntellect";
        AbilityCritChance = 0.02f;
        AbilityCritMultiplier = 1.2f;
        AbilityVariance = 0.15f;
    }
}
