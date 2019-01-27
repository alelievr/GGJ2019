using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource          happyIntro;
    public AudioSource          happyLoop;
    public AudioSource          moodLoop;

    public Transform            happyStart;
    public Transform            moodStart;
    public Transform            happyEnd;
    public Transform            moodEnd;

    GameObject player;

    void Start()
    {
    player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float s = player.transform.position.x - happyStart.position.x;
        float s2 = player.transform.position.x - moodStart.position.x;

        if (!happyIntro.isPlaying && !happyLoop.isPlaying)
        {
            Debug.Log("Play !");
            happyLoop.Play();
        }

        happyIntro.volume = Mathf.Lerp(1, 0, s / (happyEnd.position.x - happyStart.position.x));
        happyLoop.volume = Mathf.Lerp(1, 0, s / (happyEnd.position.x - happyStart.position.x));
        moodLoop.volume = Mathf.Lerp(0, 1, s2 / (moodEnd.position.x - moodStart.position.x));
    }
}
