using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform targert;
    public float speed = 15f;
    float startZ;
    Transform mTransform;

    public void Init()
    {
        startZ = transform.position.z;
        mTransform = transform;
    }

    public void Tick(Vector3 tp)
    {
        tp.z = startZ;
        mTransform.position = tp;
    }
}
