using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rotates a canvas towards camera
//used to rotate enemy healthbars towards the player

public class RotateCanvas : MonoBehaviour
{
    //Unity Camera Modes
    //public GameObject CameraSwapScriptObject;
    //public GameObject CamerasParent;

    public bool BillboardX = true;
    public bool BillboardY = true;
    public bool BillboardZ = true;
    public float OffsetToCamera;
   
    Vector3 localStartPosition;

    void Start()
    { localStartPosition = transform.localPosition; } //start rotation at objects original orientation

    void Update()
    {
        if (transform.position != null) //to prevent error when parent "dies" or is removed
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
        if (!BillboardX || !BillboardY || !BillboardZ)
            //rotate canvas based off of Euler coordinates iff different otherwise reset to 0f
            transform.rotation = Quaternion.Euler(BillboardX ? transform.rotation.eulerAngles.x : 0f, BillboardY ? transform.rotation.eulerAngles.y : 0f, BillboardZ ? transform.rotation.eulerAngles.z : 0f);
        
        transform.localPosition = localStartPosition;
        transform.position = transform.position + transform.rotation * Vector3.forward * OffsetToCamera;
    }
}
