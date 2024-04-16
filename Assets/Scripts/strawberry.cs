using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawberry : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null) {
            playerInventory.StrawberriesCollected();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
