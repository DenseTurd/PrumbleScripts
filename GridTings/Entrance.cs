using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    MeshRenderer rendy;
    public bool isActive;
    void Start()
    {
        rendy = GetComponent<MeshRenderer>();
        rendy.enabled = false;
    }
}
