using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLantern : MonoBehaviour
{
    public GameObject Lantern;
    public GameObject batteriesVisuals;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Lantern.SetActive(true); 
            Lantern.GetComponent<Lantern>().handLantern = true;
            batteriesVisuals.SetActive(true);
            Destroy(gameObject);
        }
    }
}
