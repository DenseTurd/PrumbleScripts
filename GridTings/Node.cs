using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int x;
    public int y;
    public Vector3 worldPosition;
    public bool isWall;
    public bool isEntrance;
    public bool isActiveEntrance;
    public bool isExit;
    public string exitScene;
    public NodeReferences nodeReferences;
    public ItemObject item;
}
