using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    //any scripts can read but only this one get to update or write on value
    public int NumberOfStrawberries { get; private set;}
    public int NumberOfEnemies { get; private set;}

    public UnityEvent<PlayerInventory> OnStrawberryCollected;
    public UnityEvent<PlayerInventory> OnEnemiesDefeated;

    void Start() {
        NumberOfEnemies = 0;
    }

    public void StrawberriesCollected() {
        NumberOfStrawberries++;
        OnStrawberryCollected.Invoke(this);
    }

    public void EnemiesDefeated() {
        NumberOfEnemies++;
        OnEnemiesDefeated.Invoke(this);
    }

}
