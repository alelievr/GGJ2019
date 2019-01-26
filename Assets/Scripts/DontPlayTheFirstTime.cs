using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DontPlayTheFirstTime : MonoBehaviour
{
    public Behaviour       target;

    void Start()
    {
        Debug.Log("Start unique !");
        DontDestroyOnLoad(gameObject);
        target.enabled = false;
    }
}
