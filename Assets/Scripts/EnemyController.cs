using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float        smoothTime = 0.5f;
    public GameObject   diePrefab;

    public GameObject   player;
    public bool         follow = false;
    CharacterController2D   controller2D;
    ParticleSystem.EmissionModule e;
    public bool         isDead = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller2D = GetComponent< CharacterController2D >();
        e = GetComponent< ParticleSystem >().emission;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            follow = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        e.enabled = false;
        var g = GameObject.Instantiate(diePrefab, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject, 5);
        GameObject.Destroy(g, 5);
    }

    float s;
    private void FixedUpdate()
    {
        if (follow)
        {
            var t = player.transform.position.x - transform.position.x;
            s = Mathf.SmoothDamp(t, 0, ref s, smoothTime);

            controller2D.Move(s * Time.fixedDeltaTime, false, false);
        }
    }
}
