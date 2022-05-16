using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour
{
    public float timeOut = 2.0f;
    public bool detachChildren = false;


    void Awake()
    {
        Invoke("DestroyNow", timeOut);
    }

    // Update is called once per frame
    void DestroyNow()
    {
        if (detachChildren)
        {
            transform.DetachChildren();
        }
        Destroy(gameObject);

    }
}
