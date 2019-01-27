using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinalAnimation : MonoBehaviour
{
    public PlayableDirector     playable;
    public Material             skyMaterial;
    public Material             groundMaterial;

    public float                finalAnimationValue;

    static FinalAnimation   instance;

    private void Awake()
    {
        instance = this;
    }

    public static void  StartFinalAnimation()
    {
        instance.FinalAnim();
    }

    private void Update()
    {
        skyMaterial.SetFloat("_FinalAnim", finalAnimationValue);
        groundMaterial.SetFloat("_FinalAnim", finalAnimationValue);
    }

    void FinalAnim()
    {
        playable.Play();
    }
}
