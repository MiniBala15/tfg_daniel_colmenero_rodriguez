using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreamer : MonoBehaviour
{
    public GameObject[] jumpScare;
    private float delayInSeconds = 3f;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Instantiate(jumpScare[Random.Range(0, jumpScare.Length)]);
            Invoke("changeScene", delayInSeconds);
            Cursor.lockState = CursorLockMode.None;
        }    
    }

    public void changeScene() {
        SceneManager.LoadScene(2);
    }
}
