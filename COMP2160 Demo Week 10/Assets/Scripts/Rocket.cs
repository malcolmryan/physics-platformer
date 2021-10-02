using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;   // m/s
    [SerializeField]
    private ParticleSystem explosionPrefab;
    [SerializeField]
    private float explosionRange = 2;

    private PlayerMove player;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();        
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * speed;
    }

    // void Update()
    // {
    //     transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);        
    // }

    void OnCollisionEnter2D(Collision2D other) {
        Explode();            
    }

    private void Explode()
    {
        ParticleSystem explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(explosion.gameObject, explosion.main.duration);
        Destroy(gameObject);

        Vector3 v = player.transform.position - transform.position;
        if (v.magnitude <= explosionRange)
        {
            player.Explode(v / explosionRange); 
        }
    }
}
