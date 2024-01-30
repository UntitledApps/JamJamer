using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHitSpacBehav : MonoBehaviour
{
    public Vector3 HookPos;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HookPos = other.gameObject.transform.position;
        }
        else
        {
            HookPos = Vector3.zero;
        }
    }    
}
