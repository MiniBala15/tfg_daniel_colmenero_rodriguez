using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    private float delayInSeconds = 3f;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Invoke("changeScene", delayInSeconds);
            Cursor.lockState = CursorLockMode.None;
        }    
    }

    public void changeScene() {
        SceneManager.LoadScene(3);
    }
}
