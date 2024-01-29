using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    private float camLookAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnMove(InputValue value)
    {
        moveVec = value.Get<Vector2>() * moveSpeed;
    }

    private void OnLook(InputValue value)
    {
        mouseInput = value.Get<Vector2>();

        transform.Rotate(Vector3.up,mouseInput.x * mouseSens);
        
        camLookAngle += mouseInput.y * mouseSens;
        math.clamp(camLookAngle, -89, 89);  /// ask teachers why this line is not working ?????
        
        Cam.transform.rotation = Quaternion.Euler(-camLookAngle, Cam.transform.rotation.eulerAngles.y, Cam.transform.rotation.eulerAngles.z);
 
        print(camLookAngle);
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