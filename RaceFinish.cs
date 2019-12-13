using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car; //access modified topspeed variable

//change CarController Variable : private static float m_Topspeed
// to public static float m_Topspeed

public class RaceFinish : MonoBehaviour
{
    //Unity Objects
    public GameObject playerCar;
    public GameObject finishCam;
    public GameObject viewModes;
    public GameObject lapCompleteObj;
    public GameObject LapTimeManager;
    //public GameObject lvlMusic;
    //public AUdioSource finishMusic;

    void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false; //remove collider from object when player "hits" it
        LapTimeManager.GetComponent<LapTimeManager>().enabled = false; //turn off lap times

        //kill player car speed
        playerCar.SetActive(false);
        lapCompleteObj.SetActive(false); //turn off lap complete object
        CarController.m_Topspeed = 0.0f; //set topspeed variable in car controller script to 0
        playerCar.GetComponent<CarController>().enabled = false;
        playerCar.GetComponent<CarUserControl>().enabled = false;

        //re-enable player car
        playerCar.SetActive(true);
        //lvlMusic.SetActive(false);

        finishCam.SetActive(true);
        //disable all forms of cameras to enable the "cutscene" effect
        viewModes.SetActive(false);
        //finishMusic.Play();

        StartCoroutine(AnimationWait()); // allow animation to play out without "jarring" the player

        if (other.tag == "Player")
        {
            //display win screen
            //go to next level
        }
        else //maybe need enumerator for "waiting"
        {
            //play enemy finish animator
            //play audio
            //display lose screen -> scene 
        }
    }

    IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(1);
    }
}