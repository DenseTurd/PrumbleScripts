using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    public static int isMale { get; set; }
    public static string PlayerName { get; set; }
    public static string PlayerBio { get; set; }
    public static int PlayerLevel { get; set; }
    public static BaseCharacterClass PlayerClass { get; set; }
    public static int PlayerMaxHp { get; set; }
    public static int PlayerCurrentHp { get; set; }
    public static int PlayerIntellect { get; set; }
    public static int PlayerStrength { get; set; }
    public static float PlayerEnergy { get; set; }
    public static int CurrentXP { get; set; }
    public static int RequiredXP { get; set; }
    public static int Aioes { get; set; }
    public static InventoryObject PlayerInventory { get; set; }
    public static BaseEquipment Equipment1 { get; set; }
    public static List<BaseAbility> PlayerAbilities { get; set; }
    public static string CurrentWorldScene { get; set; }
    public static bool IsInCombat { get; set; }
}
 