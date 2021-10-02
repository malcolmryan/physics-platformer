using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    [SerializeField]
    private Rocket rocketPrefab;
    private Transform firePoint;

    void Start()
    {
        firePoint = transform.Find("Fire");
    }

    void Update()
    {
    }

    public void OnFire(InputValue value)
    {
        Rocket rocket = Instantiate(rocketPrefab);
        rocket.transform.position = firePoint.position;
        rocket.transform.rotation = firePoint.rotation;
    }

    public void OnAim(InputValue value)
    {
        Vector2 aim = value.Get<Vector2>();

        if (aim.x != 0 || aim.y != 0)
        {
            float angle = Mathf.Rad2Deg * Mathf.Atan2(aim.y, aim.x);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

