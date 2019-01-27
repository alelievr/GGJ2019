using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public float        smoothTime = 0.5f;
    public GameObject   diePrefab;
    public float        speed = 2;
    public float        maxSpeed = 5;

    public GameObject   player;
    public bool         follow = false;
    CharacterController2D   controller2D;
    ParticleSystem.EmissionModule e;
    public bool         isDead = false;
    public int life = 1;
    public bool dontFollow = false;
    [Header("Events")]
    public UnityEvent onDie;
    public UnityEvent onFollow;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller2D = GetComponent< CharacterController2D >();
        e = GetComponent< ParticleSystem >().emission;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && dontFollow == false)
        {
            follow = true;
            onFollow.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet" && --life < 1)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead)
            return ;

        onDie.Invoke();
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

            s = Mathf.Clamp(s * speed, -maxSpeed, maxSpeed);
            controller2D.Move(s * speed * Time.fixedDeltaTime, false, false);
        }
        if (dontFollow)
            controller2D.Move(0, false, false);
    }
}
