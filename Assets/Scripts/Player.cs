using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float        restartScore = 8;
    public float        score01;

    CircleCollider2D    enemyCollider;
    List< EnemyController >  enemies = new List< EnemyController >();

    void Start()
    {
        enemyCollider = GetComponent< CircleCollider2D >();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
            return ;
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject.GetComponent< EnemyController >());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject.GetComponent<EnemyController >());
        }
    }

    float velo;
    void Update()
    {
        float score = 0;

        foreach (var e in enemies)
        {
            if (e == null || e.isDead)
                continue;
            score += 1.0f - (Vector3.Distance(e.transform.position, transform.position) / enemyCollider.radius);
        }

        score01 = Mathf.SmoothDamp(score01, score / restartScore, ref velo, .4f);

        if (score >= restartScore)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
