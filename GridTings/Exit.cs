using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public string exitScene;
    MeshRenderer rendy;

    private void Start()
    {
        rendy = GetComponent<MeshRenderer>();
        rendy.enabled = false;
    }

    public string GetExitScene()
    {
        return exitScene;
    }

}
