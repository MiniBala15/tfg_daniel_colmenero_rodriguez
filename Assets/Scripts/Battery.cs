using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject lantern;
    public float battery;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            lantern.GetComponent<Lantern>().remainingBattery += battery;
            Destroy(gameObject);
        }
    }
}
