using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Synchro : MonoBehaviour
{
    // Start is called before the first frame update
    List<Transform> list = new List<Transform>();
    EdgeCollider2D col;
    EnemyController e;
    void Start()
    {
        col = GetComponent<EdgeCollider2D>();
        list = GetComponentsInChildren<Transform>().ToList();
        list.RemoveAt(0);
        list.RemoveRange(list.Count -3, 3);
        e = GetComponentInParent<EnemyController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (e.follow)
        {
            if (e.player.transform.position.x - transform.position.x < 0)
                col.points = list.Select(c => (Vector2)(c.position - transform.position)).ToArray();
            else
                col.points = list.Select(c => (Vector2)(-c.position + transform.position)).ToArray();
        }
    }
}
