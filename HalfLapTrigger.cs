using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach script to HalfLap Object
//set HalfLapObj in unity to 'IsTrigger' on collider
//turn off LapCompObj && Mesh Render for both

public class HalfLapTrigger : MonoBehaviour
{
    public GameObject LapCompObj;
    public GameObject HalfLapObj;

    void OnTriggerEnter()
    {
        LapCompObj.SetActive(true);
        HalfLapObj.SetActive(false);
    }
}
