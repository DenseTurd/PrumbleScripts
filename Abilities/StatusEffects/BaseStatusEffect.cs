[System.Serializable]
public class BaseStatusEffect 
{
    public string StatusName { get; set; }
    public string StatusDescription { get; set; }
    public float StatusPower { get; set; }
    public float StatusCost { get; set; }
    public int StatusDuration { get; set; }
    public int RemainingDuration { get; set; }
    public string StatusMultiplier { get; set; }
    public float StatusVariance { get; set; }
    public float StatusCritChance { get; set; }
    public float StatusCritMultiplier { get; set; }
}
