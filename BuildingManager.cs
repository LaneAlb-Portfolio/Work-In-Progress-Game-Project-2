using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject towerToGoHere;

    void Start()
    {   }
    void Update()
    {   }
    //lets multi towers go whereever (How to put in our context dunno yet)
    //keybind to send prefab to this??
    public void SelectTowerType(GameObject Tprefab)
    {
        towerToGoHere = Tprefab;
    }
}