using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    private Vector2 aim = Vector2.zero;

    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)aim);    
    }

    public void OnFire(InputValue value)
    {

    }

    public void OnAim(InputValue value)
    {
        aim = value.Get<Vector2>();

        if (aim.x != 0 || aim.  y != 0)
        {
            float angle = Mathf.Rad2Deg * Mathf.Atan2(aim.y, aim.x);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

