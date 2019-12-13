using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

//Attach to the Spike Prefab that will slow down the player

public class SpikeHazard : MonoBehaviour
{
    //Unity Set Variable
    public int Damage;

    private int counter = 1; //controls taking double damage or double triggering of cars because of colliders

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CarController>().enabled == true && counter == 1)
        { //Player or AI Entering Takes Damage
            counter = 2;

            if (other.GetComponentInParent<CarAIControl>().enabled == true) //If AI enters then take dmg 
            {
                other.GetComponentInParent<Opponent>().TakeDamage(Damage);
            }
            else //else its the player entering then take dmg
                other.GetComponentInParent<Player>().TakeDamage(Damage);

            //Force player to decrease speed upon hitting spike
            other.GetComponentInParent<CarController>().enabled = false;
            StartCoroutine(Slow());
            
            other.GetComponentInParent<CarController>().enabled = true;
        }
        else
            return;
    }

    IEnumerator Slow() //This can be done in a better way -- Figure out how
    {
        yield return new WaitForSeconds(2);
        counter = 1;
    }

}
