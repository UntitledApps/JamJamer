using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, hookPower, mouseSens; 
    [SerializeField] private Gameobject Cam; 

    private Rigidbody rb;

    private Vector3 moveVec;
    private Vector2 mouseInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnMovement(InputValue value)
    {
        moveVec =  value.Get<Vector2>() * moveSpeed;
    }
    private void OnLook(InputValue value)
    {
        mouseInput = value.Get<Vector2>();
        
        Cam.transform.Rotate(-mouseInput.y * mouseSens, mouseInput.x * mouseSens, 0);
        
        //maybe implement a way to rotate the player on its z axis ?  
    }
    private void OnJump()
    {
        rb.AddForce(transform.forward * dashPower);
    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * moveVec.y + transform.right * moveVec.x);
    }
}