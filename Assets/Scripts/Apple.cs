using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{   
    GameObject enemy;
    private int damageAmount = 15;

    private void Start() 
    {   
        AudioManager.instance.Play("ThrowApple");
        Destroy(gameObject, 10);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerEnter(Collider other) 
    {
        //each time pass through collider
        //Destroy(transform.GetComponent<Rigidbody>());

        if (other.tag == "Enemy") {
            enemy.GetComponent<EnemyHealth>().TakeDamageApple(damageAmount);
        }
    }


}
