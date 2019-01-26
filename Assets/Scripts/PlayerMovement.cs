﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float            runSpeed = 1;
    public float            fireTimeout = 0.5f;
    public GameObject       bullet;
    public Vector2          bulletForce = new Vector2(1, 1);
    public Animator         animator;

    CharacterController2D   controller2D;
    Rigidbody2D             playerR;
    bool                    jump;
    float                   move;
    bool                    canFire = true;


    void Start()
    {
        controller2D = GetComponent< CharacterController2D >();
        playerR = GetComponent< Rigidbody2D >();
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
        animator.SetFloat("speed", Mathf.Abs(playerR.velocity.x));
        animator.SetBool("inAir", !controller2D.m_Grounded);
    }

    void Fire()
    {
        if (!canFire)
            return ;
        Vector2 force = bulletForce;
        if (!controller2D.m_FacingRight)
            force.x = -force.x;

        var g = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        var r = g.GetComponent< Rigidbody2D >();
        r.AddForce(force + Vector2.right * playerR.velocity.x, ForceMode2D.Impulse);
        StartCoroutine(FireTimeout());
    }

    IEnumerator FireTimeout()
    {
        canFire = false;
        yield return new WaitForSeconds(fireTimeout);
        canFire = true;
    }

    private void FixedUpdate()
    {
        controller2D.Move(move * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
