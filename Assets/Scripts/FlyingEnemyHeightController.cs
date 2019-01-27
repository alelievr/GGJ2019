using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHeightController : MonoBehaviour
{
    public float    speed = 0.5f;
    public float    smoothTime = 1;
    public ParticleSystem   ps;

    Rigidbody2D r;
    EnemyController e;
    ParticleSystem.EmissionModule   em;

    float   v;

    void Start()
    {
        r = GetComponent< Rigidbody2D >();
        e = GetComponent< EnemyController >();
        em = ps.emission;
        v = 0;
    }

    void Update()
    {
        if (e.isDead)
        {
            em.enabled = false;
            return ;
        }

        if (e.follow)
        {
            float targetY = e.player.transform.position.y + 2;
            float currentY = transform.position.y;

            v = Mathf.SmoothDamp(targetY - currentY, 0, ref v, smoothTime, speed);

            r.gravityScale = Mathf.Clamp(-v, -speed, speed);
        }
        if (e.dontFollow)
        {
            float targetY = e.player.transform.position.y + 2;
            float currentY = transform.position.y;

            v = Mathf.SmoothDamp(targetY - currentY, 0, ref v, smoothTime, speed);

            r.gravityScale = Mathf.Clamp(-v, -speed, speed);
        }
    }
}
