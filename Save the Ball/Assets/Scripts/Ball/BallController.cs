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
    private CameraShake cameraShake;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.bGameOver)
        {
            return;
        }

        if (other.tag == "Platform" || other.tag == "PlatformBase")
        {
            rb.velocity = new Vector2(rb.velocity.x, fPushForce);
            StartCoroutine(SquashCoroutine());
        }

        if (other.tag == "Platform")
        {
            iPushCount++;
            GameManager.instance.IncrementScore();
        }

        if (iPushCount == 4)
        {
            iPushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if (other.tag == "GameOver")
        {
            SoundManager.instance.GameOverSoundFX();
            GameManager.instance.GameOver();
        }
    }

    IEnumerator SquashCoroutine()
    {
        yield return null;

        cameraShake.Shake();
        anim.SetTrigger("Squash");
        SoundManager.instance.JumpSoundFX();
    }
}
