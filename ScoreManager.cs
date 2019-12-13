using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Unity & GUI Variables
    public GameObject PlayerCar;

    public Text moneyText;

    //Defaults
    //public int life;
    int currMoney;
    void Start() //initialize money and stuff
    {
        //initialize money and HuD
        currMoney = PlayerCar.GetComponent<Player>().money;
        moneyText.text = "$" + currMoney.ToString();
    }
    /*
    public void setLife(int loss) //for player being hit by towers
    {
        life -= loss;
        if(life <= 0)
        {
            GameOver();
        }
        lifeTxt.text = "Life: " + life.ToString(); //update life when taking damage
    }
    */
    public void decMoney(int reduction)
    {
        //update money values
        PlayerCar.GetComponent<Player>().money -= reduction; //set player money
        currMoney = PlayerCar.GetComponent<Player>().money; //set local money variable

        //update HuD
        moneyText.GetComponent<Text>().text = "$" + currMoney.ToString("F0");
    }

    public void incMoney(int increase)
    {
        //update money values
        PlayerCar.GetComponent<Player>().money += increase; //set player money
        currMoney = PlayerCar.GetComponent<Player>().money; //set local money variable

        //update HuD
        moneyText.GetComponent<Text>().text = "$" + currMoney.ToString("F0");
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        //Send to Game Over Screen instead of debug
    }

}
