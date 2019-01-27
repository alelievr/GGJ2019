using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyMode
{
    Grounder,
    Jumper,
};

public class EnemyController : MonoBehaviour
{
    public float        smoothTime = 0.5f;
    public GameObject   diePrefab;
    public float        speed = 2;
    public float        maxSpeed = 5;

    Rigidbody2D         rb;
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

    [Header("Jump enemy")]
    public Vector3      jumpForce = new Vector3(1, 3, 0);
    public float        jumpTimeout = 0.4f;
    bool                canJump = true;

    public EnemyMode    mode = EnemyMode.Grounder;

    void Start()
    {
        rb = GetComponent< Rigidbody2D >();
        player = GameObject.FindGameObjectWithTag("Player");
        controller2D = GetComponent< CharacterController2D >();
        e = GetComponent< ParticleSystem >().emission;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
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
        switch (mode)
        {
            case EnemyMode.Grounder:
                FixedUpdateGrounder();
                break ;
            case EnemyMode.Jumper:
                FixedUpdateJumper();
                break ;
            default:
                break;
        }
    }

    void FixedUpdateGrounder()
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

    void FixedUpdateJumper()
    {
        if (controller2D.m_Grounded && canJump)
            rb.velocity = Vector2.zero;

        if (follow && controller2D.m_Grounded && canJump)
        {
            var direction = Mathf.Sign(player.transform.position.x - transform.position.x);
            var jump = jumpForce;
            jump.x *= direction;
            rb.AddForce(jump, ForceMode2D.Impulse);
            Debug.Log("jump !");
            StartCoroutine(JumpTimeout());
        }
    }

    IEnumerator JumpTimeout()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpTimeout);
        canJump = true;
    }
}
