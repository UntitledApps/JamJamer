using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHitSpacBehav : MonoBehaviour
{
    public Vector3 HookPos;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cricket")
        {
            HookPos = other.gameObject.transform.position;
        }
        else
        {
            HookPos = Vector3.zero;
        }
    }    
}
