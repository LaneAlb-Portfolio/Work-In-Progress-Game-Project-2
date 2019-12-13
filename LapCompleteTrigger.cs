using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//attach to LapCompObj

public class LapCompleteTrigger : MonoBehaviour
{
    //Unity Objects
    public GameObject LapCompObj;
    public GameObject HalfLapObj;
    public GameObject minDisplay;
    public GameObject secDisplay;
    public GameObject msDisplay;
    public GameObject lapCounter;
    public GameObject raceFinishObj;
    public GameObject ScoreManager;

    //variables
    public int lapsCounter;
    public float currRawTime;
    public int moneyUponLapComplete;

    void Update()
    {
        if (lapsCounter == 2)   //hard code (number of laps required - 1)
        {
            raceFinishObj.SetActive(true);
        }
    }

    void OnTriggerEnter()
    {//IF TIME OPTIMIZE BELOW
        lapsCounter += 1;
        currRawTime = PlayerPrefs.GetFloat("RawTime");

        if (LapTimeManager.rawTime <= currRawTime)
        {
            //Final Time Manager
            if (LapTimeManager.secCount <= 9) //call manager second count var
            {
                secDisplay.GetComponent<Text>().text = "0" + LapTimeManager.secCount + ".";
            }
            else
            {
                secDisplay.GetComponent<Text>().text = "" + LapTimeManager.secCount + ".";
            }
            if (LapTimeManager.minCount <= 9) //call manager minute count var
            {
                minDisplay.GetComponent<Text>().text = "0" + LapTimeManager.minCount + ":";
            }
            else
            {
                minDisplay.GetComponent<Text>().text = "" + LapTimeManager.minCount + ":";
            }
            msDisplay.GetComponent<Text>().text = "" + LapTimeManager.msCount.ToString("F0");
        }
        //set PlayerPrefs
        PlayerPrefs.SetInt("MinSave", LapTimeManager.minCount);
        PlayerPrefs.SetInt("SecSave", LapTimeManager.secCount);
        PlayerPrefs.SetFloat("MsSave", LapTimeManager.msCount);
        PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);
        
        //reset lap time and raw
        LapTimeManager.minCount = 0;
        LapTimeManager.secCount = 0;
        LapTimeManager.msCount = 0;
        LapTimeManager.rawTime = 0;

        //increase lap counter upon finished lap
        lapCounter.GetComponent<Text>().text = "" + lapsCounter;
        //award player money for lap complete
        ScoreManager.GetComponent<ScoreManager>().incMoney(moneyUponLapComplete);

        //reset lap trigger
        HalfLapObj.SetActive(true);
        LapCompObj.SetActive(false);
    }
}
