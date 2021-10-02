using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    [SerializeField]
    private float cooldown = 0.2f;
    [SerializeField]
    private Rocket rocketPrefab;


    private Transform firePoint;
    private float cooldownTimer = 0;

    private PlayerMove player;

    void Start()
    {
        firePoint = transform.Find("Fire");
        player = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        cooldownTimer = Mathf.Max(0, cooldownTimer - Time.deltaTime);
    }

    public void OnFire(InputValue value)
    {
        if (cooldownTimer <= 0)
        {
            Rocket rocket = Instantiate(rocketPrefab);
            rocket.transform.position = firePoint.position;
            rocket.transform.rotation = firePoint.rotation;
            cooldownTimer = cooldown;

            // push back on the player
            player.Fire(firePoint.right);
        }
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

