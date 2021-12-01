[System.Serializable]
public class DigOuterThighAbility : BaseAbility
{
    public DigOuterThighAbility()
    {
        AbilityName = "DOT";
        AbilityDescription = "Digs at the outer thigh, causing damage over time.";
        AbilityPower = 0f;
        AbilityCost = 0.2f;
        AbilityStatusEffects.Add(new DigOuterThighStatus());
        AbilityCritChance = 0f;
    }
}