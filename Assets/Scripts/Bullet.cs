using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    SpriteRenderer  r;
    ParticleSystem  particle;
    Collider2D      c;

    void Start()
    {
        r = GetComponent< SpriteRenderer >();
        c = GetComponent< Collider2D >();
        particle = GetComponentInChildren< ParticleSystem >();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
            return ;

        r.enabled = false;
        c.enabled = false;
        var e = particle.emission;
        e.enabled = false;
        GameObject.Destroy(gameObject, 5);
    }
}
