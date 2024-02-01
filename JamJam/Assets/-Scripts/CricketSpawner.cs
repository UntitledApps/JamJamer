using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CricketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cricketPrefab;
    [SerializeField] private bool hasSpawned;

    [SerializeField] private float cricketSpeed = 1.5f;
    [SerializeField] private float vertOffset;
    [SerializeField] private int howManyToSpawn = 5;
    [SerializeField] private float spawnRadius = 5f;

    private void OnEnable()
    {
        hasSpawned = false;
    }

    void SpawnCricket()
    {
        Vector2 randomPos = Random.insideUnitCircle * spawnRadius;

        // Convert 2D position to 3D by adding a constant Y value
        Vector3 spawnPosition = new Vector3(randomPos.x, 1f, randomPos.y) + transform.position;

        GameObject spawnedCricket = Instantiate(cricketPrefab, spawnPosition, Quaternion.identity);
        spawnedCricket.GetComponent<Cricket>().SetSpeed(cricketSpeed);
    }


    void Spawn()
    {
        for (int i = 0; i < howManyToSpawn; i++)
        {
            SpawnCricket();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!hasSpawned)
            {
                Spawn();
                hasSpawned = true;
            }
        }
    }
}