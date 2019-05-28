using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float fPushForce = 10f;

    private int iPushCount;
    private bool bGameOver;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bGameOver)
        {
            return;
        }

        if (other.tag == "Platform")
        {
            rb.velocity = new Vector2(rb.velocity.x, fPushForce);

            iPushCount++;

            //SoundManager.instance.JumpSoundFX();
        }

        if (iPushCount == 4)
        {
            iPushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if (other.tag == "GameOver")
        {
            bGameOver = true;

            //SoundManager.instance.GameOverSoundFX();

            GameManager.instance.RestartGame();
        }
    }
}
