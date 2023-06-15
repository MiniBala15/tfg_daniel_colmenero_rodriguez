using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //Loads the scene with the name of the parameter. 
    public void changeScene(string name) {
        SceneManager.LoadScene(name);
    }
}
