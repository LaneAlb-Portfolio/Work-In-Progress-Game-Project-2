using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    //Unity Objects
    public GameObject countdownTxt; //ui countdown object
    public GameObject lapTimeMng; //ui lap time object
    public GameObject PlayerCar;  //player car
    public GameObject Opponent1; //first opponent car

    //audio files
//    public AudioSource CountAud; //3...2...1 audio file
//    public AudioSource GoAud; //"0" or start of race ding file
//    public AudioSource raceMusic; //ambient music

    void Start()
    {
        StartCoroutine(StartCount()); //call startCount
    }   

    IEnumerator StartCount(){   //optimize down the line if possible
        //first count
        yield return new WaitForSeconds(0.5f);
        countdownTxt.GetComponent<Text>().text = "3";
        //play audio
//        CountAud.Play();
        countdownTxt.SetActive(true); //set countdownUI Text as inactive

        //second count
        yield return new WaitForSeconds(1);
        countdownTxt.SetActive(false);
        countdownTxt.GetComponent<Text>().text = "2";
        //play audio
//        CountAud.Play();
        countdownTxt.SetActive(true);

        //third count
        yield return new WaitForSeconds(1);
        countdownTxt.SetActive(false);
        countdownTxt.GetComponent<Text>().text = "1";
        //play audio
//        CountAud.Play();
        //Start Race
        countdownTxt.SetActive(false);
        //play race audio and final count audio
//        GoAud.Play();
//        raceMusic.Play();
        lapTimeMng.SetActive(true); //ensure laptimer is set to false in unity
        
        //dont allow player to drive until countdown finishes
        PlayerCar.GetComponent<Rigidbody>().isKinematic = false;
        Opponent1.GetComponent<Rigidbody>().isKinematic = false;
        //turn on all AI cars at same time as Players

    }
}
