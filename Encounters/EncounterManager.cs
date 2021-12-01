using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
    float encounterTestTime;

    private void Start()
    {
        encounterTestTime = Time.time + 3;
    }
    private void Update()
    {
        if(Time.time > encounterTestTime)
        {
            EncounterTest();
        }
    }

    void EncounterTest()
    {
        encounterTestTime = Time.time + 1;
        if (Random.Range(0, 9) == 0)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
