using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBehav : MonoBehaviour
{
    [SerializeField] private float stoneSpeed, HopUp, lifeTime;
    [SerializeField] private Rigidbody rb;

    private Vector3 HopUptrajectory;
    
    
    void Start()
    {
        HopUptrajectory = new Vector3(0, HopUp,  0);
        rb.AddForce(transform.forward * stoneSpeed + HopUptrajectory);

        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    } 

}
