using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class IslandBehav : MonoBehaviour
{
    [SerializeField] private float distanceTillDestroy;
    private static int startingIslandCount;
    [SerializeField] private int IslandsPresent;
    public GameObject newIsland;
    private static GameObject newestIsland;
    public Transform playerPos;
    public bool isNewestIsland;
    private bool exitDidntHappened = true;
    private bool playerLeft;
    private Vector3 placementVec;

    private void Awake()
    {
        startingIslandCount = 5;
        
        IslandsPresent++;

        if (IslandsPresent <= startingIslandCount)
        {
            isNewestIsland = true;
        }

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (isNewestIsland)
        {
            clone();
        }

        if ((playerPos.transform.position.y - transform.position.y) > distanceTillDestroy && playerLeft)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && exitDidntHappened)
        {
            exitDidntHappened = false;
            
            newestIsland.GetComponent<IslandBehav>().isNewestIsland = true;
            playerLeft = true;
        }
    }
    private void clone()
    {
        isNewestIsland = false;

        newestIsland = Instantiate(newIsland, transform.position + GenerateVector(), Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
    }
    private Vector3 GenerateVector()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                placementVec.x = 20f;
                placementVec.z = Random.Range(-20, 20);
                break;

            case 1:
                placementVec.x = -20f;
                placementVec.z = Random.Range(-20, 20);
                break;

            case 2:
                placementVec.x = Random.Range(-20, 20);
                placementVec.z = 20f;
                break;
            
            case 3:
                placementVec.x = Random.Range(-20, 20);
                placementVec.z = -20f;
                break;
            
            default:
                print("Island Generation Error");
                break;
        }

        placementVec.y = Random.Range(15, 19);

        return placementVec;
    }
}