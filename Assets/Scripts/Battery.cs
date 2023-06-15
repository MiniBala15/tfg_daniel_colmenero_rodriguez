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

        //The player takes the battery if isInsideCollider property is true.
        if(isInsideCollider) {
            batteryMessage.text = "Has conseguido una pila (+20%) ";      
            lantern.GetComponent<Lantern>().remainingBattery += battery;
            displayTimer = Time.time + displayTime;
            batteryMessage.enabled = true;
            isDisplayingText = true;
            Destroy(gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        //After a short time, the message disappear
        if (isDisplayingText && Time.time >= displayTimer) {
            isDisplayingText = false;
            batteryMessage.enabled = false;
            batteryMessage.text = "";
        }
    }

    //Method that sets isInsideCollider to true when the player is inside the battery's collider
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isInsideCollider = true;
        }
    }

    //Method that sets isInsideCollider to false when the player is not inside the battery's collider
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            isInsideCollider = false;
        }
    }
}
