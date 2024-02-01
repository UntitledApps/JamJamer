using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper : MonoBehaviour
{
    public IslandBehav islandBehav;
    
    private void Awake()
    {
        islandBehav.isNewestIsland = true;
        
        StartCoroutine(killSelf());
    }

    IEnumerator killSelf()
    {
        yield return new WaitForSeconds(1);
    }
}
