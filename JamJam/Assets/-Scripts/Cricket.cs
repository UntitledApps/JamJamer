using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cricket : MonoBehaviour
{
    
    bool isOnGround = true;
    
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] private Transform player;
    
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void SetSpeed(float speed)
    {
        runSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, runSpeed);

    }

  

    void jumpInTheAir()
    {
        isOnGround = false;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.CompareTag("Ground"))
        {
            if(!isOnGround)
            {
                Destroy(gameObject);
            }
        }
        
           if(other.gameObject.CompareTag("Stone"))
                {
                     if (isOnGround)
                                {
                                    jumpInTheAir();
                                }   
                }
        
        
        
        
       
    }
}
