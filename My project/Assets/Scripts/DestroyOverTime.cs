using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime = 0.1f;

    void FixedUpdate()
    {
            Destroy(gameObject, lifetime);
    }
}