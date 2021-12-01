[System.Serializable]
public class BoopAbility : BaseAbility
{
    public BoopAbility()
    {
        AbilityName = "Boop";
        AbilityDescription = "A boop, More O's, more betterer.";
        AbilityPower = 0.25f;
        AbilityCost = 0.5f;
        AbilityStatMultiplier = "PlayerStrength";
        AbilityCritChance = 0.05f;
        AbilityCritMultiplier = 3f;
        AbilityVariance = 0.3f;
    }
}
