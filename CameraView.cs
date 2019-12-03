using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject standardCam;  //'0 first camera pos
    public GameObject midCam; //'1' 2nd camera pos
    public GameObject fpsCam; //'2' 3rd camera pos

    public int camMode; //integer for camera swapping

    void Update()
    {
        if (Input.GetButtonDown("View Change"))
        {
            if (camMode == 2) //change after fps cam reset to first "index" which is standard camera
            {
                camMode = 0;
            } else
            {
                camMode += 1;
            }

            StartCoroutine(ModeChange());
        }

    } //end update

    IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(0.01f); //wait a frame before changing camera view

        if(camMode == 0)
        {
            standardCam.SetActive(true);
            fpsCam.SetActive(false);
        }
        if (camMode == 1)
        {
            midCam.SetActive(true);
            standardCam.SetActive(false);
        }
        if(camMode == 2)
        {
            fpsCam.SetActive(true);
            midCam.SetActive(false);
        }
    } //end IEnum
}
