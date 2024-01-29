using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, JumpPower, hookPower, mouseSens; 
    [SerializeField] private GameObject Cam; 

    private Rigidbody rb;

    private Vector3 moveVec;
    private Vector2 mouseInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnMove(InputValue value)
    {
        moveVec =  value.Get<Vector2>() * moveSpeed;
    }
    private void OnLook(InputValue value)
    {
        mouseInput = value.Get<Vector2>();
        
        transform.Rotate(Vector3.up, mouseInput.x * mouseSens);
        
        Cam.transform.Rotate(Vector3.left, mouseInput.y * mouseSens);
        // if (Cam.transform.eulerAngles.x > 85 && Cam.transform.eulerAngles.x < 100)
        // {
        //     Cam.transform.rotation = Cam.transform.eulerAngles.x;
        // }
        
        print(Cam.transform.eulerAngles.x);
    }
    private void OnJump()
    {
        rb.AddForce(transform.up * JumpPower);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * moveVec.y + transform.right * moveVec.x;
    }
}