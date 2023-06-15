using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickLantern : MonoBehaviour
{
    private bool isInsideCollider = false;
    public GameObject Lantern;
    public GameObject batteriesVisuals;
    public Text flashlightMessage;
    public float displayTime = 2f;
    private bool isDisplayingText = false;
    private float displayTimer = 0f;

    private void Update() {
        //The player takes the flashlight if isInsideCollider property is true.
        if(isInsideCollider) {
            Lantern.SetActive(true);
            flashlightMessage.text = "Has conseguido una linterna. Pulsa (F) ";       
            displayTimer = Time.time + displayTime;
            flashlightMessage.enabled = true;
            isDisplayingText = true;
            Lantern.GetComponent<Lantern>().handLantern = true;
            batteriesVisuals.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        //After a short time, the message disappear
        if (isDisplayingText && Time.time >= displayTimer) {
            isDisplayingText = false;
            flashlightMessage.enabled = false;
            flashlightMessage.text = "";
            Destroy(gameObject);
        }
    }

    //Method that sets isInsideCollider to true when the player is inside the flashlight's collider
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = true;
        }
    }

    //Method that sets isInsideCollider to false when the player is not inside the flashlight's collider
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = false;
        }
    }
}
