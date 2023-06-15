using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Paper : MonoBehaviour
{
    bool isInsideCollider = false;
    public Light helpLight;
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
        //The player takes the paper if isInsideCollider property is true, and 'E' key is pressed.
        if(isInsideCollider && Input.GetKeyDown(KeyCode.E) && character.pickedPapers < 8) {
            character.pickedPapers += 1;     
            paperMessage.text = "Has recogido una nota ";       
            displayTimer = Time.time + displayTime;
            paperMessage.enabled = true;
            isDisplayingText = true;
            helpLight.enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        //After a short time, the message disappear
        if (isDisplayingText && Time.time >= displayTimer) {
            isDisplayingText = false;
            paperMessage.enabled = false;
            paperMessage.text = "";
            Destroy(gameObject);
        }
    }

    //Method that sets isInsideCollider to true when the player is inside the paper's collider
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = true;
        }
    }

    //Method that sets isInsideCollider to false when the player is not inside the paper's collider
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            isInsideCollider = false;
        }
    }
}
