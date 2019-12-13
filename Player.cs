using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Unity Script Managers
    public GameObject HealthBarObject;
    public GameObject TextScroller;
    //defaults
    public int health;
    public int money;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) //if Health == 0 then player lost
        {
            Lose();
        }

        TextScroller.GetComponent<ScrollingText>().PlayerIsHit(); //Call player hit scrolling image
        HealthBarObject.GetComponent<HealthBarPlayer>().SetHealth(health); //update health bar for player
    }

    public void Lose()
    {
        return; //send to gameover screen
    }
}
