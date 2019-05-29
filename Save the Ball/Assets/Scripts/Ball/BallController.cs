using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float fPushForce = 10f;

    private int iPushCount;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.bGameOver)
        {
            return;
        }

        if (other.tag == "Platform")
        {
            rb.velocity = new Vector2(rb.velocity.x, fPushForce);
            anim.SetTrigger("Squash");

            iPushCount++;
            GameManager.instance.iScore++;

            SoundManager.instance.JumpSoundFX();
        }

        if (iPushCount == 4)
        {
            iPushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if (other.tag == "GameOver")
        {
            GameManager.instance.bGameOver = true;

            SoundManager.instance.GameOverSoundFX();

            GameManager.instance.RestartGame();
        }
    }
}
