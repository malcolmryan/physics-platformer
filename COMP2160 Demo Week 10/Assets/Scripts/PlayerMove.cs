using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10;
    [SerializeField]
    private float jumpImpulse = 10;
    [SerializeField]
    private float dragCoefficient = 1;


    private new Rigidbody2D rigidbody;
    private float movement;
    private bool jump = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 drive = movement * moveForce * Vector3.right;
        rigidbody.AddForce(drive);

        Vector3 velocity = rigidbody.velocity;
        Vector3 drag = -velocity * dragCoefficient;
        drag.y = 0;
        rigidbody.AddForce(drag);

        if (jump)
        {
            rigidbody.AddForce(Vector3.up * jumpImpulse, ForceMode2D.Impulse);
            jump = false;
        }
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }

    void OnJump(InputValue value)
    {   
        jump = true;
    }

}
