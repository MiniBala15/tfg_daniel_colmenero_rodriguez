using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreamer : MonoBehaviour
{
    public GameObject[] jumpScare;
    private float delayInSeconds = 3f;

    //When the player is inside the enemy's collider, shows a jumpscare and call changeScene method and unlocks the cursor.
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Instantiate(jumpScare[Random.Range(0, jumpScare.Length)]);
            Invoke("changeScene", delayInSeconds);
            Cursor.lockState = CursorLockMode.None;
        }    
    }

    //Method that loads the scene 2
    public void changeScene() {
        SceneManager.LoadScene(2);
    }
}
