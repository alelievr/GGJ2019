using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessSlider : MonoBehaviour
{
    public float               startGamma;
    public float               endGamma;

    ColorGrading        grading;

    public Transform        start;
    public Transform        end;
    public float            currentGama;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GetComponent< PostProcessVolume >().sharedProfile.TryGetSettings< ColorGrading >(out grading);
    }

    void Update()
    {
        float s = player.transform.position.x - start.position.x;

        grading.gamma.value.w = Mathf.Lerp(startGamma, endGamma, s / (end.position.x - start.position.x));
        currentGama = grading.gamma.value.w;
    }

    public void SetGamma(float f)
    {
        grading.gamma.value.w = f;
    }
}
