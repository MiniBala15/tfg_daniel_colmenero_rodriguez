using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public GameObject[] jumpScare;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Instantiate(jumpScare[Random.Range(0, jumpScare.Length)]);
            Destroy(gameObject);            
        }    
    }
}
