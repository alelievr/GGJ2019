using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MyPostProcessManger : MonoBehaviour
{
    PostProcessVolume m_Volume;
    Vignette m_Vignette;
    ColorGrading    grading;
    Player  player;

    void Start()
    {
        player = GameObject.FindObjectOfType< Player >();
        m_Volume = GetComponent< PostProcessVolume >();
        m_Volume.sharedProfile.TryGetSettings< Vignette >(out m_Vignette);
        m_Volume.sharedProfile.TryGetSettings< ColorGrading >(out grading);
    }

    void Update()
    {
        m_Vignette.intensity.value = player.score01 * 2 - 1.2f; // don't vignete under 50%
        grading.brightness.value = Mathf.Clamp01(player.score01 * 2 - 1.5f);
    }
}
