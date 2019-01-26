using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    SpriteRenderer  r;
    ParticleSystem  particle;

    void Start()
    {
        r = GetComponent< SpriteRenderer >();
        particle = GetComponentInChildren< ParticleSystem >();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        r.enabled = false;
        var e = particle.emission;
        e.enabled = false;
        GameObject.Destroy(gameObject, 5);
    }
}
