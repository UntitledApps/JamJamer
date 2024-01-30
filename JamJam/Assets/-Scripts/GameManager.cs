using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxIslands;
    [SerializeField] private GameObject newIsland;
    
    List<GameObject> Islands = new List<GameObject>();

    // private void Start()
    // {
    //     for (int i = 0; i <= maxIslands; i++)
    //     {
    //         Islands.Add(Instantiate(newIsland, Vector3., Quaternion.identity));
    //     }
    // }
}