using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    //defaults
    public int health = 10;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    { // optimize down the line if possible
        Destroy(gameObject);
    }
}
