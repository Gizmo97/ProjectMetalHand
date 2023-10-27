using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cam;
    public Rigidbody rbody;

    [Header("PLAYER SETTINGS")]
    public Vector3 moveVector;
    public Vector2 turnVector;
    public float turnSmoothTime = 0.1f;
    float turnSmoothvelocity;
    public float walkSpeed = 7f;
    public float jumpHeight = 3f;

    [Header("GROUND CHECK")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;   
    bool isGrounded;
   
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.rotation = cam.transform.rotation;
        }
        
        //storing input, I cleaned this up.
        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
                
        //THIS IS THE MAGIC, SO FAR
        if (moveVector != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothvelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * walkSpeed * Time.deltaTime);
        }
    }

    public void GroundCheck() 
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    public void Jumping() 
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rbody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }
    }
}