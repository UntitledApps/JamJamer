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
    [SerializeField] private float destroyTimer;
    [SerializeField] private GameObject newIsland;
    private static GameObject newestIsland;
    public bool isNewestIsland, exitHappened;

    private Vector3 placementVec;
    private void FixedUpdate()
    {
        if (isNewestIsland)
        {
            clone();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !exitHappened)
        {
            exitHappened = false;
            
            newestIsland.GetComponent<IslandBehav>().isNewestIsland = true;
            StartCoroutine(DestroyTimer());
        }
    }
    private void clone()
    {
        isNewestIsland = false;

        newestIsland = Instantiate(newIsland, transform.position + GenerateVector(), Quaternion.identity);
        //print("Island Cloned !");
    }
    private Vector3 GenerateVector()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                placementVec.x = 20f;
                placementVec.z = Random.Range(-20, 20);
                print("1");
                break;

            case 1:
                placementVec.x = -20f;
                placementVec.z = Random.Range(-20, 20);
                print("2");
                break;

            case 2:
                placementVec.x = Random.Range(-20, 20);
                placementVec.z = 20f;
                print("3");
                break;
            
            case 3:
                placementVec.x = Random.Range(-20, 20);
                placementVec.z = -20f;
                print("4");
                break;
            
            default:
                print("Island Generation Error");
                break;
        }

        placementVec.y = Random.Range(15, 19);

        print(placementVec);
        return placementVec;
    }
    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this);
    }
}