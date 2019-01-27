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
        Debug.Log("Start unique !");
        DontDestroyOnLoad(gameObject);
        target.enabled = false;
        active = true;
    }
    private void Start()
    {
        SceneManager.sceneLoaded += (e, s) => {
            if (active)
            {
                GameObject g = GameObject.Find("TitleScreenVcam");
                if (g != null)
                    g.SetActive(false);
            }
        };
    }
}
