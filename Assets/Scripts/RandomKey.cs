using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKey : MonoBehaviour
{   
    public GameObject houseKey;

    // Start is called before the first frame update
    void Start()
    {   

        Vector3 randomPosition = new Vector3(Random.Range(-100,101), 30, Random.Range(-100,101));
        Instantiate(houseKey, randomPosition, Quaternion.identity);
    }

    
}
