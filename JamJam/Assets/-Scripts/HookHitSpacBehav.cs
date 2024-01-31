using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class HookHitSpacBehav : MonoBehaviour
{
    [NonSerialized] public Vector3 hookPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cricket"))
        {
            hookPos = other.gameObject.transform.position;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Cricket"))
        {
            hookPos = other.gameObject.transform.position;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cricket"))
        {
            hookPos = Vector3.zero;
        }
    }
}
