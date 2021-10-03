using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float groundMoveForce = 20;
    [SerializeField]
    private float airMoveForce = 10;

    [SerializeField]
    private float jumpImpulse = 10;
    [SerializeField]
    private float fireImpulse = 10;
    [SerializeField]
    private AnimationCurve explosinImpulse;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float maxGroundDistance = 1;

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

    // Mathf.Sign returns 1 for x == 0
    private float Sign(float x)
    {
        if (x == 0)
        {
            return 0;
        }
        else if (x > 0)
        {
            return 1;
        }
        else 
        {
            return -1;
        }
    }

    void FixedUpdate()
    {
        float vx = rigidbody.velocity.x;
        float drive = (IsOnGround() ? groundMoveForce : airMoveForce);
        rigidbody.AddForce(drive * movement * Vector3.right);

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
            rigidbody.AddForce(explodeDirection.normalized * impulse, ForceMode2D.Impulse);
            explode = false;
        }
    }

    private bool IsOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, maxGroundDistance, groundLayer);
        return hit.collider != null;
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }

    void OnJump(InputValue value)
    {   
        if (IsOnGround())
        {
            jump = true;
        }
    }

    public void Fire(Vector3 direction)
    {
        fire = true;
        fireDirection = direction;
    }

    public void Explode(Vector3 direction)
    {
        explode = true;
        explodeDirection = direction;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + maxGroundDistance * Vector3.down);    
    }
}