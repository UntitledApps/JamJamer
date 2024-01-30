using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HookHitSpacBehav : MonoBehaviour
{
    public Vector3 hookPos;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = other.gameObject.transform.position;
        }
        else
        {
            hookPos = Vector3.zero;
        }
    }
}
