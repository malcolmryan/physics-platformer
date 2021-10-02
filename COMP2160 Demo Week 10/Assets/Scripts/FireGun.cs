using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float dx = Input.GetAxis(InputAxes.GunHorizontal);
        float dy = Input.GetAxis(InputAxes.GunVertical);
        Vector2 aim = new Vector2(dx, dy);

        if (dx != 0 && dy != 0)
        {
            float angle = Vector2.Angle(Vector2.right, aim);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
