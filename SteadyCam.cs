using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach script to cube above car that is a parent to camera

public class SteadyCam : MonoBehaviour
{
    public GameObject CarPrefab;   //set in unity actual player car used

    public float xVal;
    public float yVal;
    public float zVal;

    void Update()
    {
        xVal = CarPrefab.transform.eulerAngles.x;
        yVal = CarPrefab.transform.eulerAngles.y;
        zVal = CarPrefab.transform.eulerAngles.z;

        //keep x and z axis static while in motion
        transform.eulerAngles = new Vector3(xVal - xVal, yVal, zVal - zVal); 
    }

}
