using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    //LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}