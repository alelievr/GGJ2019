using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float            runSpeed = 1;
    public float            fireTimeout = 0.5f;
    public GameObject       bullet;
    public Vector2          bulletForce = new Vector2(1, 1);

    CharacterController2D   controller2D;
    bool                    jump;
    float                   move;
    bool                    canFire = true;


    void Start()
    {
        controller2D = GetComponent< CharacterController2D >();
    }

    private void Update()
    {
        move = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector2 force = bulletForce;
        if (!controller2D.m_FacingRight)
            force.x = -force.x;

        var g = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        var r = g.GetComponent< Rigidbody2D >();
        r.AddForce(force, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        controller2D.Move(move * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
