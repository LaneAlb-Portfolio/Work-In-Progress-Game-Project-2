using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//attach to empty game object w/in hierarchy

public class LapTimeManager : MonoBehaviour
{
    //static time variables
    public static int minCount;
    public static int secCount;
    public static float msCount;
    public static string msDisplay;
    public static float rawTime;

    //UI Objects
    public GameObject minObj;
    public GameObject secObj;
    public GameObject msObj;

    void Update()
    {
        msCount += Time.deltaTime * 10;
        rawTime += Time.deltaTime * 10;
        msDisplay = msCount.ToString("F0");
        msObj.GetComponent<Text>().text = "" + msDisplay;

        //Time output to UI management
        if(msCount >= 10)
        {
            msCount = 0;
            secCount += 1;
        }
        if(secCount <= 9)
        {
            secObj.GetComponent<Text>().text = "0" + secCount + ".";
        }
        else
        {
            secObj.GetComponent<Text>().text = "" + secCount + ".";
        }
        if(secCount >= 60)
        {
            secCount = 0;
            minCount += 1;
        }
        if(minCount <= 9)
        {
            minObj.GetComponent<Text>().text = "0" + minCount + ":";
        }
        else
        {
            minObj.GetComponent<Text>().text = "" + minCount + ":";
        }
    }

}

