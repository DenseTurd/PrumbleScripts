using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer 
{
    public string PlayerName { get; set; }
    public int Playerlevel { get; set; }
    public BaseCharacterClass PlayerClass { get; set; }
    public int PlayerHp { get; set; }
    public int PlayerCurrentHp { get; set; }
    public int PlayerIntellect { get; set; }  // magic damage modifier? mana pool?
    public int PlayerStrength { get; set; }
    public int CurrentXP { get; set; }
    public int RequiredXP { get; set; }
    public int Aioes { get; set; } //currency
    public int StatPointsToAllocate { get; set; }
}
