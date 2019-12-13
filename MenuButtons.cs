using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for loading scenes

public class MenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //use scene # of the first track
    }
    public void Options()
    {
      //  SceneManager.LoadScene(#); //insert loadscene for options
    }
    public void Credits()
    {
       // SceneManager.LoadScene(#); //insert loadscene for credits
    }
    public void Controls()
    {
        //SceneManager.LoadScene(#); //insert loadscene for cntrls
    }
    public void QuitGame()
    {
        //SceneManager.LoadScene(#); //insert quit game / application
    }

    //Universal "Go Back" Button
     public void GoBack()
    {
        SceneManager.LoadScene(0); //use scene # of main menu
    }

    //Race Menu Buttons

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextRace()
    {
        SceneManager.LoadScene(2);
    }
}
