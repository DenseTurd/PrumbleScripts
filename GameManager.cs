using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager 
{
    public static void RestoreHealth(int val)
    {
        GameInfo.PlayerCurrentHp += val;
        Debug.Log("Restored " + val + " Health.");
    }
}
