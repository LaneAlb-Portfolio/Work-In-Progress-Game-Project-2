using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    //Unity Objects
    public GameObject ScoreManager;
    public GameObject HealthBarObject; //allows health to updates without using Update() method
    public GameObject TextScroller;
    //defaults can set in unity
    public int health = 100;
    public int value = 10;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Die();
        }
        TextScroller.GetComponent<ScrollingText>().OppntDamaged(); //call opponent dmged scrolling image
        HealthBarObject.GetComponent<HealthBarEnemy>().SetHealth(health); //update health bar for opponent
    }

    public void Die()
    { // optimize down the line if possible
        TextScroller.GetComponent<ScrollingText>().OpponentDeath(); //let player know opponent died
        ScoreManager.GetComponent<ScoreManager>().incMoney(value); //give player money for defeating opponent
        
        Destroy(gameObject);
    }
}
