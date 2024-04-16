using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{   
    private int HP = 100;
    private int punchDamageAmount = 20;
    public Animator animator;
    private float? deadTime;
    private bool playDeadOnce = true;

    UnityEngine.AI.NavMeshAgent agent;
    Transform player;

    //HealthBar
    public Slider healthBar;

    public bool inRange;

    private GameObject playerInventory;
   

    void Start()
    {
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
       player = GameObject.FindGameObjectWithTag("Player").transform;
       playerInventory = GameObject.FindGameObjectWithTag("Player"); //.EnemiesDefeated()
       agent.speed = 4.5f;
       inRange = false;
    }
    

    public void TakeDamageApple(int damageAmount) {


        if (HP > 0) {
            HP -= damageAmount;
            Debug.Log(HP);
        }
            
        if (HP <= 0 && playDeadOnce) {
            //play death sound effects
            AudioManager.instance.Play("EnemyDestroyed");
            //play death animation
            animator.SetTrigger("isDead");
            GetComponent<Collider>().enabled = false;
            deadTime = Time.time;
            playDeadOnce = false;

            playerInventory.GetComponent<PlayerInventory>().EnemiesDefeated();
        }
    }

    void Update() {

        if (Input.GetKeyDown("c")) {
            if(inRange) {
                if (HP > 0) {
                    AudioManager.instance.Play("Punch");
                    HP -= punchDamageAmount;
                } 

                if (HP <= 0 && playDeadOnce) {
                //play death sound effects
                AudioManager.instance.Play("EnemyDestroyed");
                //play death animation
                animator.SetTrigger("isDead");
                GetComponent<Collider>().enabled = false;
                deadTime = Time.time;
                playDeadOnce = false;
                playerInventory.GetComponent<PlayerInventory>().EnemiesDefeated();
                }
                    
            }
        }

        healthBar.value = HP;

        if (Time.time - deadTime > 5) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        //each time pass through collider
        //Destroy(transform.GetComponent<Rigidbody>());
            if (other.tag == "Player") {
                inRange = true;
                agent.SetDestination(player.position);
                //float distance = Vector3.Distance(player.position, animator.transform.position);
               
                //Debug.Log(HP);
            }
                
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
                inRange = false;
               
                //Debug.Log(HP);
        }
    }
}





