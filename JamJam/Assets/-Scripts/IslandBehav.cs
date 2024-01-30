using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class IslandBehav : MonoBehaviour
{
    public delegate void AddIsland();
    public static event AddIsland addIsland;

    public bool isNewestIsland;
    [SerializeField] private float destroyTimer;

    [SerializeField] private GameObject newIsland;
    private GameObject clone;

    private Vector3 TestVector = new Vector3(20, 20, 0);

    private void OnEnable()
    {
        addIsland += addNewIsland;
    }
    private void OnDisable()
    {
        addIsland -= addNewIsland;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            addIsland();
        }
    }

    private void addNewIsland()
    {
        if (isNewestIsland)
        {
            isNewestIsland = false;
            
            Instantiate(newIsland, TestVector, Quaternion.identity);
            
            if (clone != null)
            {
                clone.GetComponent<IslandBehav>().isNewestIsland = true;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyTimer());
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
    }
}