using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car; //access modified topspeed variable

public class RaceFinish : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject finishCam;
    public GameObject viewModes;
    public GameObject lapCompleteObj;
    //public GameObject lvlMusic;
    //public AUdioSource finishMusic;

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false; //remove collider from object when player "hits" it

        //kill player car speed
        playerCar.SetActive(false);
        lapCompleteObj.SetActive(false); //turn off lap complete object
        CarController.m_Topspeed = 0.0f; //set topspeed variable in car controller script to 0
        playerCar.GetComponent<CarController>().enabled = false;
        playerCar.GetComponent<CarUserControl>().enabled = false;

        //re-enabled player car
        playerCar.SetActive(true);
        //lvlMusic.SetActive(false);
        finishCam.SetActive(true);
        //disable all forms of cameras to enable the "cutscene" effect
        viewModes.SetActive(false);
        //finishMusic.Play();
    }
}