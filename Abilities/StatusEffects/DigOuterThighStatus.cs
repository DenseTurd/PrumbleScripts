[System.Serializable]

public class DigOuterThighStatus : BaseStatusEffect
{
    public DigOuterThighStatus()
    {
        StatusName = "DOT";
        StatusDescription = "Digs the outer thigh, causing damage over time.";
        StatusPower = 0.1f;
        StatusCost = 0.3f;
        StatusDuration = 3;
        StatusMultiplier = "PlayerStrength";
        StatusVariance = 0.2f;
        StatusCritChance = 0.1f;
        StatusCritMultiplier = 1.5f;
    }
}
