using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopFalling : MonoBehaviour
{   
    private bool touch = false;
    Vector3 p;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Terrain") 
        {
             this.GetComponent<Rigidbody>().useGravity = false;
             touch = true;
             p = transform.position;
             p.y += 1;
             Debug.Log("OK");
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(touch)
        {
            //
            transform.position = p;
        }
    }
}
