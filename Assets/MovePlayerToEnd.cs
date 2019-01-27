using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToEnd : MonoBehaviour
{
    public Transform                target;
    public PlayerMovement           player;
    public CharacterController2D    playerController;
    public bool                     moveToEnd;

    [Header("Music !")]
    public Transform                backgrounMusic;

    void Start()
    {
        player = FindObjectOfType< PlayerMovement >();
        playerController = player.GetComponent< CharacterController2D >();
    }

    public float speed = 3;
    public float maxSpeed = 20;
    public float smoothTime = 0.3f;
    float s;
    void Update()
    {
        if (moveToEnd)
        {
            player.lockKeyboard = true;

            var t = player.transform.position.x - target.transform.position.x;
            s = Mathf.SmoothDamp(t, 0, ref s, smoothTime);

            Debug.Log("Move player to end: " + s);
            s = Mathf.Clamp(-s * speed, -maxSpeed, maxSpeed);
            playerController.Move(s * speed * Time.fixedDeltaTime, false, false);

            backgrounMusic.position = Vector3.MoveTowards(backgrounMusic.position, target.position, 80 * Time.deltaTime);
        }
    }
}
