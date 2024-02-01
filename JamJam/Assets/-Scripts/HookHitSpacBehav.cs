using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class HookHitSpacBehav : MonoBehaviour
{
    [NonSerialized] public GameObject hookedEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cricket"))
        {
            hookedEnemy = other.gameObject;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Cricket"))
        {
            hookedEnemy = other.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cricket"))
        {
            hookedEnemy = null;
        }
    }
}
