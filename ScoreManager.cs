using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Defaults
    public int life = 100;
    //GUI Variables
    public Text lifeTxt;

    public void LoseLife(int l = 10) //for player being hit by towers
    {
        life -= l;
        if(life <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        //Send to Game Over Screen instead of debug
    }

    void Update()
    {
        //Fix: update at a slower pace 1-per-frame is excessive
        lifeTxt.text = "Life: " + life.ToString();
    }
}
