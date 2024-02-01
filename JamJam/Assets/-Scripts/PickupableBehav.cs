using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableBehav : MonoBehaviour
{
    private Transform playerPos;
    
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if ((playerPos.transform.position.y - transform.position.y) > 120)
        {
            Destroy(this.gameObject);
        }
    }
}
