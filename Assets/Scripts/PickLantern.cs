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
        if(isInsideCollider) {
            Lantern.SetActive(true);
            flashlightMessage.text = "Has conseguido una linterna. Pulsa (F) ";       
            displayTimer = Time.time + displayTime;
            flashlightMessage.enabled = true;
            isDisplayingText = true;
            Lantern.GetComponent<Lantern>().handLantern = true;
            batteriesVisuals.SetActive(true);
        }

        if (isDisplayingText && Time.time >= displayTimer) {
            isDisplayingText = false;
            flashlightMessage.enabled = false;
            flashlightMessage.text = "";
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = false;
        }
    }
}
