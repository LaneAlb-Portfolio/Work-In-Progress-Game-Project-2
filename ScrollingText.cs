using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    //Player and AI objects
    public GameObject Player;
    public GameObject Opponent1;
    public GameObject Opponent2;
    public GameObject Opponent3;
    
    //Prewritten Text / Images
    //ensure Images / Text are disabled in Unity
    public GameObject TowerBuiltMsg;
    public GameObject OpponentDamaged;
    public GameObject OpponentDestroyed;
    public GameObject AllOpponentsDestroyed;
    public GameObject PlayerHit;

    //Activate game object with image then start coroutine with specific image
    public void PlayerIsHit()
    {
        PlayerHit.SetActive(true);
        Scroll(PlayerHit);
    }

    public void OppntDamaged()
    {
        OpponentDamaged.SetActive(true);
        Scroll(OpponentDamaged); 
    }

    public void OpponentDeath()
    {
        OpponentDestroyed.SetActive(true);
        Scroll(OpponentDestroyed);
    }

    public void TowerBuilt()
    {
        TowerBuiltMsg.SetActive(true);
        Scroll(TowerBuiltMsg); 
    }

    public void Scroll(GameObject i)
    {
        StartCoroutine(Animation(i));
    }

    IEnumerator Animation(GameObject i) //Wait for Animations then turn off game object
    {
        i.GetComponent<Animation>().Play();
        
        yield return new WaitForSeconds(2.1f);
        i.SetActive(false);
    }
}
