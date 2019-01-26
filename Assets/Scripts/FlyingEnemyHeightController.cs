using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHeightController : MonoBehaviour
{
    public float    speed = 0.5f;
    public float    smoothTime = 1;

    Rigidbody2D r;
    EnemyController e;

    float   v;

    void Start()
    {
        r = GetComponent< Rigidbody2D >();
        e = GetComponent< EnemyController >();
        v = 0;
    }

    void Update()
    {
        if (e.follow)
        {
            float targetY = e.player.transform.position.y + 2;
            float currentY = transform.position.y;

            v = Mathf.SmoothDamp(targetY - currentY, 0, ref v, smoothTime, speed);

            r.gravityScale = Mathf.Clamp(-v, -speed, speed);
        }
    }
}
