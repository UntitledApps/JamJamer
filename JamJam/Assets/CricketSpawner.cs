using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject cricketPrefab;
    [SerializeField] private bool hasSpawned = false;
    [SerializeField] private float spawnDelay = 1.5f;
    [SerializeField] private int howManyToSpawn = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void SpawnCricket()
    {
        Instantiate(cricketPrefab, transform.position, Quaternion.identity);
    }

    Vector3 randomPosition()
    {
         return transform.position + new Vector3(UnityEngine.Random.Range(-5, 5), transform.position.y + 5, UnityEngine.Random.Range(-5, 5));
    }

    void Spawn()
    {
        for(int i = 0; i < howManyToSpawn; i++)
        {
            Invoke(nameof(SpawnCricket), spawnDelay);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
           if(!hasSpawned)
           {

               Spawn();
               hasSpawned = true;


           }
       }
    }
}
