using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupHitSpaceBehav : MonoBehaviour
{
    [NonSerialized] public GameObject pickedUpObject;
    private void OnTriggerEnter(Collider other)
    {
        pickedUpObject = other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        pickedUpObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        pickedUpObject = null;
    }
}