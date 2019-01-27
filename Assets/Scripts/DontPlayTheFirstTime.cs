using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using Cinemachine;

public class DontPlayTheFirstTime : MonoBehaviour
{
    static bool            active = false;
    public Behaviour                    target;

    void Awake()
    {
        if (active)
            return ;
        active = true;
        Debug.Log("Start unique !");
        DontDestroyOnLoad(gameObject);
        target.enabled = false;
        SceneManager.sceneLoaded += (e, s) => {
            GameObject g = GameObject.Find("TitleScreenVcam");
            if (g != null)
                g.SetActive(false);
        };
    }
}
