using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToEnd : MonoBehaviour
{
    public Transform                target;
    public PlayerMovement           player;
    public CharacterController2D    playerController;
    public bool                     moveToEnd;

    void Start()
    {
        player = FindObjectOfType< PlayerMovement >();
        playerController = player.GetComponent< CharacterController2D >();
    }

    float speed = 1;
    float maxSpeed = 2;
    float smoothTime = 0.5f;
    float s;
    void Update()
    {
        if (moveToEnd)
        {
            player.enabled = false;

            var t = player.transform.position.x - target.transform.position.x;
            s = Mathf.SmoothDamp(t, 0, ref s, smoothTime);

            s = Mathf.Clamp(s * speed, -maxSpeed, maxSpeed);
            playerController.Move(s * speed * Time.fixedDeltaTime, false, false);
        }
    }
}
