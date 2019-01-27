using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class RestartZone : MonoBehaviour
{
    BoxCollider2D   box;
    void Start()
    {
        box = GetComponent< BoxCollider2D >();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {

    }
}
