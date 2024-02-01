using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private bool hasSpawned = false;
    [SerializeField] private int howManyToSpawn = 5;
    [SerializeField] private float spawnRadius = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }


    void SpawnStones()
    {
        for (int i = 0; i < howManyToSpawn; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPos.x, 0f, randomPos.y) + transform.position;
            Instantiate(stonePrefab, spawnPosition, Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!hasSpawned)
            {
                SpawnStones();
                hasSpawned = true;
            }
        }
    }
}