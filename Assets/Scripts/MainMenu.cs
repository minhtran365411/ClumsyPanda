using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    //public int difficulty; 
    private static readonly string DifficultyPrefs = "DifficultyPrefs";
    //1= easy, 15 mins, 10 evil pandas, 10 apples
    //2 = medium, 10 mins, 15 evil pandas, 18 apples
    //3 = hard, 5 mins, 20 evil pandas, 25 apples

    public void EasyMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt(DifficultyPrefs, 1);
        
        //difficulty = 1;
    }

    public void MediumMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt(DifficultyPrefs, 2);
        //difficulty = 2;
    }

    public void HardMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt(DifficultyPrefs, 3);
        //difficulty = 3;
    }

    public void Exit()
    {
        Application.Quit();
    }

}
