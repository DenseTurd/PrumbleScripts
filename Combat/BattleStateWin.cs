using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStateWin
{
   public void Win(CombatData combatData)
   {
        ExperienceManager.AddExperience(combatData.enemy.Enemylevel);
        SceneManager.LoadScene(GameInfo.CurrentWorldScene);    
   }
}
