using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateXToPlayer : MonoBehaviour
{
    EnemyController e;
    void Start()
    {
        e = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (e.follow)
        {
            Debug.Log("dfsf");
            transform.right = ((Vector3)((Vector2)e.player.transform.position -(Vector2)transform.position)).normalized;
        }
    }
}
