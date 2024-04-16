using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI1 : MonoBehaviour
{
    private TextMeshProUGUI strawberryText;

    private static readonly string DifficultyPrefs = "DifficultyPrefs";
    private int difficultyLevel;

    public string applesToGet;
    public string fullAppleText;

    // Start is called before the first frame update
    void Start()
    {
        strawberryText = GetComponent<TextMeshProUGUI>();
        difficultyLevel = PlayerPrefs.GetInt(DifficultyPrefs);
        //Debug.Log(PlayerPrefs.GetInt(DifficultyPrefs));

        switch(difficultyLevel)
        {
            case 1:
                applesToGet = "10";
                break;
            case 2:
                applesToGet = "18";
                break;
            case 3:
                applesToGet = "25";
                break;
            default:
                Debug.Log("No Setting");
                break;
        }

        strawberryText.text = "0/"+applesToGet;

    }

    public void UpdateStrawberryText(PlayerInventory playerInventory) {
        fullAppleText = playerInventory.NumberOfStrawberries.ToString()+" / "+applesToGet;
        strawberryText.text = fullAppleText;
    }

}
