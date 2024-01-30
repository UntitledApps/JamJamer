using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class IslandBehav : MonoBehaviour
{
    public bool isNewIsland;
    [SerializeField] private float destroyTimer;

    public UnityEvent addIsland;
    [SerializeField] private GameObject newIsland;
    private GameObject clone;

    private Vector3 TestVector = new Vector3(20, 20, 0);

    private void Start()
    {
        addIsland.AddListener(addNewIsland);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            addIsland.Invoke();
        }
    }

    private void addNewIsland()
    {
        if (isNewIsland)
        {
            Instantiate(newIsland, TestVector, Quaternion.identity);
            
            isNewIsland = false;
            if (clone != null)
            {
                clone.GetComponent<IslandBehav>().isNewIsland = true;
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