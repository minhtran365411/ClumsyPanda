using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DoorMasking : MonoBehaviour
{
    int bitMask = 1;
    public GameObject winCanvas;
    public UnityEvent GamePaused;

    private static readonly string DifficultyPrefs = "DifficultyPrefs";
    private int difficultyLevel;

    //Countdown timer
	[SerializeField]
	private float CountUp = 0;
	public TextMeshProUGUI timerText;
    private bool winState = false;

    private int minutes;
    private int seconds;
    

    public GameObject onestar;
    public GameObject twostars;
    public GameObject threestars;


    private void OnTriggerEnter(Collider col) 
    {
        //Debug.Log("Collided");
        if((col.gameObject.GetComponent<PlayerMovement>().attribute & bitMask) == bitMask) {
            AudioManager.instance.Play("OpenDoor");
            if (difficultyLevel == 1 )
            {
                if (col.gameObject.GetComponent<PlayerInventory>().NumberOfStrawberries >= 10 && col.gameObject.GetComponent<PlayerInventory>().NumberOfEnemies >= 10) {
                        this.GetComponent<BoxCollider>().isTrigger = true;
                        //winCanvas = GameObject.FindGameObjectsWithTag("Winning");
                        winCanvas.SetActive(true);
                        Time.timeScale = 0;
                        GamePaused.Invoke();
                        winState = true;

                            //timer
                            if(minutes < 4)
                            {
                                threestars.SetActive(true);
                            } else if (minutes < 8)
                            {
                                twostars.SetActive(true);
                            } else {
                                onestar.SetActive(true);
                            }

                    }
            } else if (difficultyLevel == 2 )
            {
                if (col.gameObject.GetComponent<PlayerInventory>().NumberOfStrawberries >= 18 && col.gameObject.GetComponent<PlayerInventory>().NumberOfEnemies >= 15) {
                        this.GetComponent<BoxCollider>().isTrigger = true;
                        //winCanvas = GameObject.FindGameObjectsWithTag("Winning");
                        winCanvas.SetActive(true);
                        Time.timeScale = 0;
                        GamePaused.Invoke();
                        winState = true;

                            //timer
                            if(minutes < 4)
                            {
                                threestars.SetActive(true);
                            } else if (minutes < 8)
                            {
                                twostars.SetActive(true);
                            } else {
                                onestar.SetActive(true);
                            }
                    }
            } else if (difficultyLevel == 3 )
            {
                if (col.gameObject.GetComponent<PlayerInventory>().NumberOfStrawberries >= 25 && col.gameObject.GetComponent<PlayerInventory>().NumberOfEnemies >= 20) {
                        this.GetComponent<BoxCollider>().isTrigger = true;
                        //winCanvas = GameObject.FindGameObjectsWithTag("Winning");
                        winCanvas.SetActive(true);
                        Time.timeScale = 0;
                        GamePaused.Invoke();
                        winState = true;

                            //timer
                            if(minutes < 4)
                            {
                                threestars.SetActive(true);
                            } else if (minutes < 8)
                            {
                                twostars.SetActive(true);
                            } else {
                                onestar.SetActive(true);
                            }

                    }
            }
            
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
        // Debug.Log("Leaving collider");
        // this.GetComponent<BoxCollider>().isTrigger = false;
        // other.gameObject.GetComponent<PlayerMovement>().attribute &= ~bitMask;
    //}

    //Start is called before the first frame update
    void Start()
    {   
        difficultyLevel = PlayerPrefs.GetInt(DifficultyPrefs);

        // if (this.gameObject.tag == "House")
        // {
        //     bitMask |= 1;
        // }
    }

    // Update is called once per frame
	void Update () 
	{
		if (winState == false)
        {
            //Increase time
		    CountUp += Time.deltaTime;
        }

        minutes = Mathf.FloorToInt(CountUp / 60F);
		seconds = Mathf.FloorToInt(CountUp - minutes * 60);
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = niceTime;

	}

}
