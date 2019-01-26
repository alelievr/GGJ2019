using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float        speed = 20;
    public GameObject   diePrefab;

    public GameObject   player;
    public bool         follow = false;
    CharacterController2D   controller2D;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller2D = GetComponent< CharacterController2D >();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger: " + other.tag);
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
        GameObject.Instantiate(diePrefab, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);
    }

    float s;
    private void FixedUpdate()
    {
        if (follow)
        {
            var t = player.transform.position.x - transform.position.x;
            s = Mathf.SmoothDamp(t + Mathf.Sign(t) * 2, 0, ref s, 1, speed * Time.fixedDeltaTime);

            Debug.Log("move: " + s);
            controller2D.Move(s * Time.fixedDeltaTime, false, false);
        }
    }
}
