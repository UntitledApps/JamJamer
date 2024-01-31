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

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cricket"))
        {
            hookPos = other.gameObject.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            hookPos = Vector3.zero;
        }
    }
}
