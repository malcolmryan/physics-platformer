using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10;
    private float dragCoefficient = 1;
    private new Rigidbody2D rigidbody;
    private float movement;

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
        rigidbody.AddForce(drag);

    }

    void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }

    void OnJump(InputValue value)
    {

    }

}
