using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    public int life = 3;
    public float cd = 0.5f;
    int olife;
    float time;
    public Animator animator;
    Spawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        olife = life;
        time = 0;
        spawn = GetComponentInChildren<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (life < olife && time > cd)
        {
            life++;
            time = 0;
        }
        animator.SetBool("live", life > 0);
        spawn.enabled = life > 0;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
            life--;
    }
}
