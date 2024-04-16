using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHeart : MonoBehaviour
{   
    //public float HealAmount = 200f;

    private void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Player") {

            Health H = col.gameObject.GetComponent<Health>();
            if (H == null) return;
            H.HealthPoints = 100f;
            AudioManager.instance.Play("Collected");
            Destroy(gameObject);
        }
    }

}
