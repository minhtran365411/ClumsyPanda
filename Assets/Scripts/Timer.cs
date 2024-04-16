//-------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

//-------------------------
public class Timer : MonoBehaviour
{
	//Countdown
	[SerializeField]
	private float CountUp = 0;
	public TextMeshProUGUI timerText;

	//-------------------------
	// Update is called once per frame
	void Update () 
	{
		//Increase time
		CountUp += Time.deltaTime;

		int minutes = Mathf.FloorToInt(CountUp / 60F);
		int seconds = Mathf.FloorToInt(CountUp - minutes * 60);

		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);


        timerText.text = niceTime;

	}
	//-------------------------
}
//-------------------------