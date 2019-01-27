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
            Vector3 diff = e.player.transform.position;
            diff.Normalize();
    
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z +  180);
        }
    }
}
