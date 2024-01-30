using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StoneSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    [FormerlySerializedAs("cricketPrefab")] [SerializeField] private GameObject stonePrefab;
    [SerializeField] private bool hasSpawned = false;
    [SerializeField] private float spawnDelay = 1.5f;
    [SerializeField] private int howManyToSpawn = 5;
    [SerializeField] private float spawnRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void SpawnCricket()
    {
        Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            
        // Convert 2D position to 3D by adding a constant Y value
        Vector3 spawnPosition = new Vector3(randomPos.x, 0f, randomPos.y) + transform.position;

        // Instantiate the item prefab at the generated position
        Instantiate(stonePrefab, spawnPosition, Quaternion.identity);
        GameObject spawnedCricket =  Instantiate(stonePrefab, transform.position, Quaternion.identity);
    
        
    }

 
    void Spawn()
    {
        for(int i = 0; i < howManyToSpawn; i++)
        {
            Invoke(nameof(SpawnCricket), spawnDelay);
        }
    }

    private void OnTriggerEnter(Collider other)
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