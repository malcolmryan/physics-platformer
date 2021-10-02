using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;   // m/s

    [SerializeField]
    private ParticleSystem explosionPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Explode();    
    }

    private void Explode()
    {
        ParticleSystem explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(explosion.gameObject, explosion.main.duration);
        Destroy(gameObject);
    }
}
