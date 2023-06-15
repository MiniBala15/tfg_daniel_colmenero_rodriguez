using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public GameObject[] jumpScare;

    //When the player is inside the object's collider, shows a jumpscare for a few seconds.
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Instantiate(jumpScare[Random.Range(0, jumpScare.Length)]);
            Destroy(gameObject);            
        }    
    }
}
