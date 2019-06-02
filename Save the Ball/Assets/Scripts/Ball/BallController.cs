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
        if (GameManager.instance.bGamePaused)
        {
            return;
        }

        if (other.tag == "Platform" || other.tag == "PlatformStart")
        {
            rb.velocity = new Vector2(rb.velocity.x, fPushForce);
            StartCoroutine(SquashCoroutine());
        }

        if (other.tag == "PlatformEnd")
        {
            SoundManager.instance.FinishSoundFX();
            GameManager.instance.LevelPassed();
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
