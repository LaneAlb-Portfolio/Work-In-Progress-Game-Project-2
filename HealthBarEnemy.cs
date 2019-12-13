using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    //Unity GUI Components
    public Image HealthBarImg;
    public Text HealthBarText;
    public GameObject EnemyObject; //specify "parent" that this health bar relates to

    //grab health values from opponent script and min from Unity
    public float HealthMin = 0; 
    float HealthMax;
    
    //get health values from parent
    float currentVal;
    float currentPercent;

    void Start() //set max health from parent
    { HealthMax = EnemyObject.GetComponent<Opponent>().health; }

    public void SetHealth(int hp)
    {
        currentVal = hp;
        currentPercent = currentVal / (HealthMax - HealthMin);

        //set GUI Components
        HealthBarText.text = Mathf.RoundToInt(currentPercent * 100).ToString("0F");
        HealthBarImg.fillAmount = currentPercent;
    }  
}
