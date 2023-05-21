using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour
{
    public Light lanternLight;
    public bool isActive;
    public bool handLantern;
    public float remainingBattery = 100;
    public float batteryLoss = 0.5f;

    [Header("Visuals")]
    public Image battery1;
    public Image battery2;
    public Image battery3;
    public Image battery4;
    public Sprite emptyBattery;
    public Sprite loadedBattery;
    public Text batteryPercentage;

    void Update()
    {
        remainingBattery = Mathf.Clamp(remainingBattery, 0, 100);
        int batteryValue = (int)remainingBattery;
        batteryPercentage.text = batteryValue.ToString() + "%";

        if(Input.GetKeyDown(KeyCode.F) && handLantern == true) {
            isActive = !isActive;
            if(isActive == true) {
                lanternLight.enabled = true;
            }

            if(isActive == false) {
                lanternLight.enabled = false;
            }
        }

        if(isActive == true && remainingBattery > 0) {
            remainingBattery -= batteryLoss * Time.deltaTime;
        }

        if(remainingBattery == 0) {
            lanternLight.intensity  = 0f;
            battery1.sprite = emptyBattery;
        }

        if(remainingBattery > 0 && remainingBattery <= 25) {
            lanternLight.intensity = 1f;
            battery1.sprite = loadedBattery;
            battery2.sprite = emptyBattery;
        }

        if(remainingBattery > 25 && remainingBattery <= 50) {
            lanternLight.intensity = 1.5f;
            battery2.sprite = loadedBattery;
            battery3.sprite = emptyBattery;
        } 

        if(remainingBattery > 50 && remainingBattery <= 75) {
            lanternLight.intensity = 2f;
            battery3.sprite =  loadedBattery;
            battery4.sprite = emptyBattery;
        }
        
        if(remainingBattery > 75 && remainingBattery <= 100) {
            lanternLight.intensity = 2.5f;
            battery4.sprite = loadedBattery;
        } 
    }
}
