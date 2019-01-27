using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WindVolume : MonoBehaviour
{
    public AudioSource         target;

    PostProcessVolume  vol;
    BoxCollider         box;

    GameObject player;

    void Start()
    {
        vol = GetComponent< PostProcessVolume >();
        player = GameObject.FindGameObjectWithTag("Player");
        box = GetComponent< BoxCollider >();
    }

    void Update()
    {
        float b = 0;
        float bmin = box.bounds.min.x;
        float bmax = box.bounds.max.x;

        if (box.bounds.Contains(player.transform.position))
            b = 1;
        else if (player.transform.position.x < bmin)
        {
            b = Mathf.Lerp(0, 1, (player.transform.position.x - bmin + vol.blendDistance) / vol.blendDistance);
        }
        else
        {
            b = Mathf.Lerp(1, 0, (player.transform.position.x - bmax - vol.blendDistance) / vol.blendDistance);
        }

        target.volume = b;
    }
}
