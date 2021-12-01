using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyClass
{

    public string EnemyClassName { get; set; }
    public string EnemyClassDescription { get; set; }
    public int EnemyHp { get; set; }
    public int EnemyCurrentHp { get; set; }
    public int EnemyStrength { get; set; }
    public int EnemyIntellect { get; set; }
    public int EnemyAioes { get; set; }

    public List<BaseAbility> EnemyAbilities = new List<BaseAbility>();

}
