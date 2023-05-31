using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Paper : MonoBehaviour
{
    bool isInsideCollider = false;
    public int pickedPages;
    int totalPages = 8;
    public Text paperMessage;
    public float displayTime = 2f;
    private bool isDisplayingText = false;
    private float displayTimer = 0f;
    public FPSCamera character;

    void Start() 
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSCamera>();
    }

    void Update()
    {
        if(isInsideCollider && Input.GetKeyDown(KeyCode.E)) {
            character.pickedPapers += 1;     
            paperMessage.text = "Has recogido una nota ";       
            displayTimer = Time.time + displayTime;
            paperMessage.enabled = true;
            isDisplayingText = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (isDisplayingText && Time.time >= displayTimer) {
            isDisplayingText = false;
            paperMessage.enabled = false;
            paperMessage.text = "";

        }

        // if(totalPages >= 8) {
        //     win();
        // }
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
