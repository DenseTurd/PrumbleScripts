using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNode : MonoBehaviour
{
    MeshRenderer rendy;
    public ItemObject item;

    private void Start()
    {
        rendy = GetComponent<MeshRenderer>();
        rendy.enabled = false;
    }
}
