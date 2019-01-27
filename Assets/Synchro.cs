using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Synchro : MonoBehaviour
{
    // Start is called before the first frame update
    List<Transform> list = new List<Transform>();
    EdgeCollider2D col;
    void Start()
    {
        col = GetComponent<EdgeCollider2D>();
        list = GetComponentsInChildren<Transform>().ToList();
        list.RemoveAt(0);
        list.RemoveRange(list.Count -3, 3);

    }

    // Update is called once per frame
    void Update()
    {
        col.points = list.Select(c => (Vector2)(transform.position - c.position)).ToArray();
    }
}
