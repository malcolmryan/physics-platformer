using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    private Vector2 aim = Vector2.zero;

    void Start()
    {
        
    }

    void Update()
    {
        float dx = Input.GetAxis(InputAxes.GunHorizontal);
        float dy = Input.GetAxis(InputAxes.GunVertical);
        aim = new Vector2(dx, dy);

        if (dx != 0 || dy != 0)
        {
            float angle = Mathf.Rad2Deg * Mathf.Atan2(dy, dx);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)aim);    
    }

}

