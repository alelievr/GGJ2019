using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class FinalAnimation : MonoBehaviour
{
    public PlayableDirector     playable;
    public Material             skyMaterial;
    public Material             groundMaterial;
    public MovePlayerToEnd          movePlayerToEnd;
    public GameObject           playerVcam;

    public bool                 trigger = false;

    public float                finalAnimationValue;

    PostProcessSlider           pps;

    static FinalAnimation   instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pps = GameObject.FindObjectOfType<PostProcessSlider>();
        movePlayerToEnd = FindObjectOfType< MovePlayerToEnd >();
        skyMaterial.SetFloat("_FinalAnim", 0);
        groundMaterial.SetFloat("_FinalAnim", 0);
    }

    public static void  StartFinalAnimation()
    {
        instance.FinalAnim();
    }

    private void Update()
    {
        skyMaterial.SetFloat("_FinalAnim", finalAnimationValue);
        groundMaterial.SetFloat("_FinalAnim", finalAnimationValue);
        if (!pps.enabled)
        {
            pps.SetGamma(Mathf.Lerp(pssStartValue, 0, finalAnimationValue));
        }

        if (trigger)
        {
            FinalAnim();
            trigger = false;
        }
    }

    float pssStartValue;
    public void FinalAnim()
    {
        foreach (var e in GameObject.FindObjectsOfType< EnemyController >())
        {
            Destroy(e.gameObject);
        }
        playerVcam.SetActive(false);
        movePlayerToEnd.moveToEnd = true;
        pps.enabled = false;
        pssStartValue = pps.currentGama;
        playable.Play();
    }
}
