using System.Collections;
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

    bool oldGrounded = false;

    private void Update()
    {
        move = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        if (oldGrounded != controller2D.m_Grounded && !controller2D.m_Grounded)
        {
            StartCoroutine(SetInAir());
        }

        oldGrounded = controller2D.m_Grounded;
        animator.SetFloat("speed", Mathf.Abs(playerR.velocity.x));
        if (controller2D.m_Grounded)
            animator.SetBool("inAir", false);
    }

    IEnumerator SetInAir()
    {
        yield return new WaitForSeconds(0.1f);
        if (!controller2D.m_Grounded)
            animator.SetBool("inAir", true);
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
