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
    [SerializeField] private float mouseSens, moveSpeed, JumpPower, hookPower, hookVertPush;
    [SerializeField] private GameObject Cam, Stone, StoneHolder, GrassHolder;
    [SerializeField] private HookHitSpacBehav HookHitSpacBehav;

    private Rigidbody rb;

    private Vector3 moveVec, hookVec, origVelo;
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

        transform.Rotate(Vector3.up, mouseInput.x * mouseSens);

        camLookAngle = Mathf.Clamp(camLookAngle + mouseInput.y * mouseSens, -89, 89);

        Cam.transform.rotation = Quaternion.Euler(-camLookAngle,
            Cam.transform.rotation.eulerAngles.y, Cam.transform.rotation.eulerAngles.z);
    }
    private void OnJump()
    {
        rb.AddForce(transform.up * JumpPower);
    }
    private void OnFire()
    {
        Instantiate(Stone, StoneHolder.transform.position, StoneHolder.transform.rotation);
    }
    private void OnHook()
    {
        if (HookHitSpacBehav.hookPos != Vector3.zero)
        {
            hookVec.x = HookHitSpacBehav.hookPos.x - transform.position.x * hookPower;
            hookVec.z = HookHitSpacBehav.hookPos.z - transform.position.z * hookPower;
            hookVec.y = hookVertPush;
            
            rb.AddForce(hookVec);
        }   
    }
    private void FixedUpdate()
    {
        rb.velocity += transform.forward * moveVec.y + transform.right * moveVec.x;
        
        // print(hookVec);
    }
}