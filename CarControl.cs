using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class CarControl : MonoBehaviour
{
    public GameObject PlayerCar; //player's car object

    void Start()
    { //only allow player to move when script is called
        PlayerCar.GetComponent<CarController>().enabled = true;    
    }

}
