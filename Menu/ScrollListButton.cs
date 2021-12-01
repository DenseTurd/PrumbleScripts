using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollListButton : MonoBehaviour
{
    public TMP_Text buttonText;
    public int abilityListIndex;
    public BattleGUI battleGUI;

    public void OnClick()
    {
        battleGUI.ActionSelect(abilityListIndex);
    }
}
