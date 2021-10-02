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
    private float fireImpulse = 10;
    [SerializeField]
    private AnimationCurve explosinImpulse;
    
    private new Rigidbody2D rigidbody;
    private float movement;
    private bool jump = false;
    private bool fire = false;
    private Vector3 fireDirection = Vector3.zero;
    private bool explode = false;
    private Vector3 explodeDirection = Vector3.zero;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 drive = movement * moveForce * Vector3.right;
        rigidbody.AddForce(drive);

        if (jump)
        {
            rigidbody.AddForce(Vector3.up * jumpImpulse, ForceMode2D.Impulse);
            jump = false;
        }

        if (fire) 
        {
            rigidbody.AddForce(-fireDirection.normalized * fireImpulse, ForceMode2D.Impulse);
            fire = false;
        }

        if (explode)
        {
            float impulse = explosinImpulse.Evaluate(explodeDirection.magnitude);
            Debug.Log($"Explosion impulse = {impulse}");
            rigidbody.AddForce(explodeDirection.normalized * impulse, ForceMode2D.Impulse);
            explode = false;
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

    public void Fire(Vector3 direction)
    {
        fire = true;
        fireDirection = direction;
    }

    public void Explode(Vector3 direction)
    {
        Debug.Log($"Explode({direction})");
        explode = true;
        explodeDirection = direction;
    }
}