using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageFromEnemy : MonoBehaviour
{
    //------------------------------
    //Damage per second
    public float DamageRate = 3f;

    
    //------------------------------
    void OnTriggerStay(Collider Col)
    {
        Health H = Col.gameObject.GetComponent<Health>();

        if (H == null) return;

        H.HealthPoints -= DamageRate * Time.deltaTime;
       
    }
    //------------------------------
}
