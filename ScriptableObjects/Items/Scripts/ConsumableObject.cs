using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable")]
public class ConsumableObject : ItemObject, IUseable
{
    public int restoreHpVal;
    public void Awake()
    {
        type = ItemType.Consumable;
    }
    public override void Use()
    {
        GameManager.RestoreHealth(7);
        if (GameInfo.IsInCombat)
        {
            CombatStateMachine.playerCompletedTurn = true;
            CombatStateMachine.currentState = CombatStateMachine.battleStates.playerCalculationsStatusEffects;
        }
    }
}
