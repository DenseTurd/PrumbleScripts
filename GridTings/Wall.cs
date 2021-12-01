using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    MeshRenderer rendy;

    private void Start()
    {
        rendy = GetComponent<MeshRenderer>();
        rendy.enabled = false;
    }
}
