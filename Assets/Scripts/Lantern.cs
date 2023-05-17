using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Light lanternLight;
    public bool isActive;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            isActive = !isActive;
            if(isActive == true) {
                lanternLight.enabled = true;
            }

            if(isActive == false) {
                lanternLight.enabled = false;
            }
        }
    }
}
