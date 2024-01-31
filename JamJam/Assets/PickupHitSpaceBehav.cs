using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHitSpaceBehav : MonoBehaviour
{
    [SerializeField] private PlayerBehav playerBehav;

    private void OnTriggerEnter(Collider other)
    {
        playerBehav.isHittingStone = true;
    }

    private void OnTriggerStay(Collider other)
    {
        playerBehav.isHittingStone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerBehav.isHittingStone = false;
    }
}