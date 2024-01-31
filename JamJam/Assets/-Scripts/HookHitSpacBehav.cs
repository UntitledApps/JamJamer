using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class HookHitSpacBehav : MonoBehaviour
{
    public Vector3 hookPos;
    // private void OnTriggerEnter(Collision other)
    // {
    //     print("asojdf");
    //     if (other.gameObject.tag == "Cricket")
    //     {
    //         hookPos = other.gameObject.transform.position;
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        print("asojdf");
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = other.gameObject.transform.position;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = other.gameObject.transform.position;
            
            print(hookPos);
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = Vector3.zero;
        }
    }
}
