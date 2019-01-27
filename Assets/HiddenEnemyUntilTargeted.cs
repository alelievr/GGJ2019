using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenEnemyUntilTargeted : MonoBehaviour
{
    public ParticleSystem   main;
    public ParticleSystem   second;

    ParticleSystem.EmissionModule   mainE;
    ParticleSystem.EmissionModule   secondE;

    void Start()
    {
        mainE = main.emission;
        secondE = second.emission;

        mainE.enabled = false;
        secondE.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EnableParticles();
        }
    }

    void EnableParticles()
    {
        mainE.enabled = true;
        secondE.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
