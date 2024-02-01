using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehav : MonoBehaviour
{
    [SerializeField] private float mouseSens, moveSpeed, groundedSpeed, JumpPower, hookPower, hookVertPush;
    [SerializeField] private Transform Cam, Stone, StoneHolder, GrassHolder, CricketPullPos;
    [SerializeField] private GameObject StoneDisplay;
    [SerializeField] private HookHitSpacBehav HookHitSpaceBehav;
    [SerializeField] private PickupHitSpaceBehav PickupHitSpaceBehav;
    private Vector3 moveVec, hookVec, origVelo, pushToCricketPullPos;
    private Vector2 mouseInput;
    private float camLookAngle;
    private bool grounded, hasStone;
    [NonSerialized] public bool isHittingStone = false;
    private Rigidbody rb;

    // sasd
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        StoneDisplay.SetActive(false);
    }

    private void OnMove(InputValue value)
    {
        if (grounded)
        {
            moveVec = value.Get<Vector2>() * groundedSpeed;
        }
        else
        {
            moveVec = value.Get<Vector2>() * moveSpeed;
        }
    }

    private void OnLook(InputValue value)
    {
        mouseInput = value.Get<Vector2>();

        transform.Rotate(Vector3.up, mouseInput.x * mouseSens);

        camLookAngle = Mathf.Clamp(camLookAngle + mouseInput.y * mouseSens, -89, 89);

        Cam.transform.rotation = Quaternion.Euler(-camLookAngle, Cam.transform.rotation.eulerAngles.y, Cam.transform.rotation.eulerAngles.z);
    }

    private void OnJump()
    {
        if (grounded)
        {
            rb.AddForce(transform.up * JumpPower);
        }
    }

    private void OnFire()
    {
        if (hasStone)
        {
            Instantiate(Stone, StoneHolder.transform.position, StoneHolder.transform.rotation);
            StoneDisplay.SetActive(false);
            hasStone = false;   
        }
        else if (PickupHitSpaceBehav.pickedUpObject != null)
        {
            Destroy(PickupHitSpaceBehav.pickedUpObject);
            hasStone = true;
            StoneDisplay.SetActive(true);
        }
    }

    private void OnHook()
    {
        if (HookHitSpaceBehav.hookedEnemy != null)
        {
            HookHitSpaceBehav.hookedEnemy.tag = "Cricket";
            HookHitSpaceBehav.hookedEnemy.GetComponent<BoxCollider>().enabled = !HookHitSpaceBehav.hookedEnemy.GetComponent<BoxCollider>().enabled;
            
            hookVec.x = (HookHitSpaceBehav.hookedEnemy.transform.position.x - transform.position.x) * hookPower;
            hookVec.z = (HookHitSpaceBehav.hookedEnemy.transform.position.z - transform.position.z) * hookPower;
            hookVec.y = hookVertPush;
            rb.AddForce(hookVec);

            pushToCricketPullPos = CricketPullPos.transform.position - HookHitSpaceBehav.hookedEnemy.transform.position;
            
            HookHitSpaceBehav.hookedEnemy.GetComponent<Rigidbody>().AddForce(pushToCricketPullPos * 300);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity += transform.forward * moveVec.y + transform.right * moveVec.x;
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            print("sdf");
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
        }
    }
}