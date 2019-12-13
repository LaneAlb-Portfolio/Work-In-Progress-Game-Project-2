using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create cube on player car like for cameras called finish cube

public class FinishAnimator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 1, 0, Space.World);
    }
}