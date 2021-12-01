[System.Serializable]
public class BopAbility : BaseAbility
{
   public BopAbility()
    {
        AbilityName = "Bop";
        AbilityDescription = "Bop it!";
        AbilityPower = 0.1f;
        AbilityCost = 0.1f;
        AbilityStatMultiplier = "PlayerStrength";
        AbilityCritChance = 0.05f;
        AbilityCritMultiplier = 1.2f;
        AbilityVariance = 0.1f;
    }
}
