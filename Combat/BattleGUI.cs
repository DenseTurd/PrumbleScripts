using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour
{
    public TMP_Text playerValHp;
    public Image playerValEnergy;

    public TMP_Text enemyValHP;

    public ScrollRect actionsScrollRect;
    public GameObject scrollListButton;

    public DialogueManager dialogueManager;
   

   

    void Start()
    {
        CombatStateMachine.battleGUIScript = this;
        PopulateActionsScrollRect();
        dialogueManager = GetComponent<DialogueManager>();
    }
    public void UpdateGUI(CombatData combatData)
    {
        playerValEnergy.fillAmount = GameInfo.PlayerEnergy;
        playerValHp.text = GameInfo.PlayerCurrentHp.ToString() + "/" + GameInfo.PlayerMaxHp.ToString();
        enemyValHP.text = combatData.enemy.EnemyCurrentHp.ToString() +"/" + combatData.enemy.EnemyHp.ToString();

    }
    
    public void ActionSelect(int abilityListIndex)
    {
        CombatStateMachine.allyCombatData.usedAbility = GameInfo.PlayerAbilities[abilityListIndex];
        CombatStateMachine.allyCombatData.abilityIndex = abilityListIndex;
    }

    public void PopulateActionsScrollRect()
    {
        for (int i = 0; i < GameInfo.PlayerAbilities.Count; i++)
        {
            GameObject button = Instantiate(scrollListButton) as GameObject;
            ScrollListButton scrollListButtonScript = button.GetComponent<ScrollListButton>();
            scrollListButtonScript.buttonText.text = (GameInfo.PlayerAbilities[i].AbilityName);
            scrollListButtonScript.abilityListIndex = i;
            scrollListButtonScript.battleGUI = this;
            button.transform.SetParent(actionsScrollRect.content, false); 
        }
    }

    public void CreateActionSelectedDialogue(CombatData combatData, string name)
    {
        Dialogue dialogue = new Dialogue();
        dialogue.sentences = new string[1] { name + " did " + combatData.usedAbility.AbilityName + "." };
        UpdateLog(dialogue);
    }
    public void CreateCausedDamageDialogue(string adversaryName, int damage, bool crit)
    {
        Dialogue dialogue = new Dialogue();
        dialogue.sentences = new string[1] { "" };
        if (crit)
        {
            dialogue.sentences[0] +=  "It crit! " ;
        }
        
        dialogue.sentences[0] += adversaryName + " took " + (int) damage + " damage.";
        UpdateLog(dialogue);
    }
    public void CreateCausedStatusDamageDialogue(string adversaryName, int damage, string statusName)
    {
        Dialogue dialogue = new Dialogue();
        dialogue.sentences = new string[1] { adversaryName + " took " + (int)damage + " damage from " + statusName};
        UpdateLog(dialogue);
    }

    public void UpdateLog(Dialogue dialogue)
    {
        dialogueManager.StartDialogue(dialogue);
    }
   
}
