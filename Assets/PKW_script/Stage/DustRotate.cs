using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustRotate : MonoBehaviour
{
    public float speed = 30f;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
