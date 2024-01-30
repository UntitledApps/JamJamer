using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class HookHitSpacBehav : MonoBehaviour
{
    public Vector3 hookPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = other.gameObject.transform.position;
            
            print(hookPos);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = other.gameObject.transform.position;
            
            print(hookPos);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = Vector3.zero;
        }
    }

    private void Update()
    {
    }
}
