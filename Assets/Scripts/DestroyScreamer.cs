using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScreamer : MonoBehaviour
{
    public float time;

    //Destroys the jumspcare object after a few seconds.
    void Start()
    {
        Destroy(gameObject, time);   
    }

}
