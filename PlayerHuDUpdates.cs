using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHuDUpdates : MonoBehaviour
{
    //Unity Objects
    public GameObject PlayerCar;
    public Text moneyText;
    //in game chat objects here

    //local variables
    int currMoney;


    void Start() //initialize money and stuff
    {
        currMoney = PlayerCar.GetComponent<Player>().money;
    }

    public void setMoney(int reduction)
    {
        //update money and Output update
        currMoney -= PlayerCar.GetComponent<Player>().money;
        moneyText.GetComponent<Text>().text = "$" + currMoney.ToString("0F");

    }
}
