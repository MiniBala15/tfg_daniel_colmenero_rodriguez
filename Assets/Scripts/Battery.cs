using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battery : MonoBehaviour
{
    public GameObject lantern;
    public float battery;
    bool isInsideCollider = false;
    public Text batteryMessage;
    public float displayTime = 2f;
    private bool isDisplayingText = false;
    private float displayTimer = 0f;

    void Update()
    {
        if(isInsideCollider) {
            batteryMessage.text = "Has conseguido una pila (+20%) ";      
            lantern.GetComponent<Lantern>().remainingBattery += battery;
            displayTimer = Time.time + displayTime;
            batteryMessage.enabled = true;
            isDisplayingText = true;
        }

        if (isDisplayingText && Time.time >= displayTimer) {
            isDisplayingText = false;
            batteryMessage.enabled = false;
            batteryMessage.text = "";
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            isInsideCollider = false;
        }
    }
}
