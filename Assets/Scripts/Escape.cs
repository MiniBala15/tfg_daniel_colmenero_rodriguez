using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    private float delayInSeconds = 0.2f;

    //When the player is inside the door's collider, call changeScene method and unlocks the cursor.
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            changeScene();
            Cursor.lockState = CursorLockMode.None;
        }    
    }

    //Method that loads the scene 3
    public void changeScene() {
        SceneManager.LoadScene(3);
    }
}
