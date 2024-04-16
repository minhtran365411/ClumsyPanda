using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyInventory : MonoBehaviour
{
    private TextMeshProUGUI enemiesText;

    private static readonly string DifficultyPrefs = "DifficultyPrefs";
    private int difficultyLevel;

    public string enemiesToGet;

    // Start is called before the first frame update
    void Start()
    {
        enemiesText = GetComponent<TextMeshProUGUI>();
        difficultyLevel = PlayerPrefs.GetInt(DifficultyPrefs);
        //Debug.Log(PlayerPrefs.GetInt(DifficultyPrefs));

        switch(difficultyLevel)
        {
            case 1:
                enemiesToGet = "10";
                break;
            case 2:
                enemiesToGet = "15";
                break;
            case 3:
                enemiesToGet = "20";
                break;
            default:
                Debug.Log("No Setting");
                break;
        }

        enemiesText.text = "0/"+enemiesToGet;

    }

    public void UpdateEnemiesDefeated(PlayerInventory playerInventory) {
        enemiesText.text = playerInventory.NumberOfEnemies.ToString()+" / "+enemiesToGet;
    }
}
