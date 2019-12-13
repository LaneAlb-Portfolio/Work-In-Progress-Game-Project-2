using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    //get Tower to manage
    public GameObject TowerToManage;
    public GameObject PlayerCar;
    public GameObject ScoreManager;
    public GameObject ScrollingTxtObj;

    void OnTriggerEnter() //when player enters under tower, Spawn tower and enable it to shoot if they  have money to build
    {
        if (PlayerCar.GetComponent<Player>().money >= TowerToManage.GetComponent<ModularTower>().towerValue)
        {
            //Place and Activate Tower
            TowerToManage.GetComponent<ModularTower>().enabled = true;
            ScrollingTxtObj.GetComponent<ScrollingText>().TowerBuilt(); //call scrolling text for tower built
            //Update Player Money and HuD
            ScoreManager.GetComponent<ScoreManager>().decMoney(TowerToManage.GetComponent<ModularTower>().towerValue);

            //Output To Text Chat that tower was built
        }
        else
            return;//output not enough money to text chat
    }
}