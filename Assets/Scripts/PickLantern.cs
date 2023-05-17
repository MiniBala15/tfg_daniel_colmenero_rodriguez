using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLantern : MonoBehaviour
{
    public GameObject Lantern;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Lantern.SetActive(true);
            Lantern.GetComponent<Lantern>().handLantern = true;
            Destroy(gameObject);
        }
    }
}
