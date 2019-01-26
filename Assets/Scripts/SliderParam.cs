using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SliderParam : MonoBehaviour
{
    public CinemachineVirtualCamera playerVcam;
    public float            startValue;
    public float            endValue;
    public float            startYOffset;
    public float            endYOffset;
    public Transform        start;
    public Transform        end;

    GameObject player;
    CinemachineTransposer    transposer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transposer = playerVcam.GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update()
    {
        float s = player.transform.position.x - start.position.x;

        playerVcam.m_Lens.OrthographicSize = Mathf.Lerp(startValue, endValue, s / (end.position.x - start.position.x));
        transposer.m_FollowOffset.y = Mathf.Lerp(startYOffset, endYOffset, s / (end.position.x - start.position.x));
    }
}
