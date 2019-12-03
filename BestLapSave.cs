using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script allows best lap time to persist after game close

public class BestLapSave : MonoBehaviour
{
    //unity UI objects
    public GameObject bestMinDisplay;
    public GameObject bestSecDisplay;
    public GameObject bestMsDisplay;

    //best time save variables
    public int minCountBest;
    public int secCountBest;
    public float msCountBest;

    void Start()
    {
        //save specific ("best") player lap times
        minCountBest = PlayerPrefs.GetInt("minSave");
        secCountBest = PlayerPrefs.GetInt("secSave");
        msCountBest = PlayerPrefs.GetFloat("msSave");

        //Output Best Lap Time to Ui Objects
        bestMinDisplay.GetComponent<Text>().text = "" + minCountBest + ":";
        bestSecDisplay.GetComponent<Text>().text = "" + secCountBest + ".";
        bestMsDisplay.GetComponent<Text>().text = "0" + msCountBest.ToString("F0");
    }
}
