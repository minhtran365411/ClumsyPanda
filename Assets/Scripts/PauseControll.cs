using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseControll : MonoBehaviour
{   
    private bool muted = false; 
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;
    private bool _isPause;
    public GameObject PauseMenu;
 
    

    public void PauseGame() 
    {
        Time.timeScale = 0;
        GamePaused.Invoke();
        PauseMenu.SetActive(true);
    }

    public void Resume() {
        Time.timeScale = 1;
        GameResumed.Invoke();
        PauseMenu.SetActive(false);
    }

    public void Mute() {
        if(muted == false) {
                muted = true;
                AudioListener.pause = true;
            } else {
                muted = false;
                AudioListener.pause = false;
            }
    }

    public void MainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    void Update() {
        if (Input.GetKeyDown("p")) {
            _isPause = !_isPause;

            if(_isPause) {
                Time.timeScale = 0;
                GamePaused.Invoke();
                PauseMenu.SetActive(true);
            } else {
                Time.timeScale = 1;
                GameResumed.Invoke();
                PauseMenu.SetActive(false);
            }
        }

        if (Input.GetKeyDown("m")) {
            if(muted == false) {
                muted = true;
                AudioListener.pause = true;
            } else {
                muted = false;
                AudioListener.pause = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }


    }

    

}
