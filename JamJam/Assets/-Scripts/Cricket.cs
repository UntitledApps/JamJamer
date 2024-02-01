    using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cricket : MonoBehaviour
{
    bool hasntJumpedYet = true;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float runSpeed = 4f;
    private Transform playerPos;
    
    private Rigidbody rb;
    
    private Vector3 lookDirection;
    private AnimationC
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void SetSpeed(float speed)
    {
        runSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move towards the target
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, runSpeed * Time.deltaTime);

        // Calculate the direction to the target
        Vector3 targetPosition = playerPos.position;
        targetPosition.y = transform.position.y;
        Vector3 lookDirection = (targetPosition - transform.position).normalized;

        // Calculate the rotation towards the target
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        targetRotation *= Quaternion.Euler(0, -90, 0);

        // Rotate towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);

        if ((playerPos.transform.position.y - transform.position.y) > 100)
        {
            Destroy(this.gameObject);
        }
    }
    void jumpInTheAir()
    {
        hasntJumpedYet = false;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            if(!hasntJumpedYet)
            {
                Destroy(gameObject);
            }
        }
        if(other.gameObject.CompareTag("Stone"))
        {
            if (hasntJumpedYet)
            {
                gameObject.tag = "HitableCricket";
                jumpInTheAir();
            }   
        }
    }
}
