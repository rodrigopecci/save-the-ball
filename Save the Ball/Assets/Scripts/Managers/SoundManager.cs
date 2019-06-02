using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip jumpClip, finishClip, gameOverClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void JumpSoundFX()
    {
        if (!GameManager.instance.bGamePaused)
        {
            soundFX.clip = jumpClip;
            soundFX.Play();
        }
    }

    public void FinishSoundFX()
    {
        if (!GameManager.instance.bGamePaused)
        {
            soundFX.clip = finishClip;
            soundFX.Play();
        }
    }

    public void GameOverSoundFX()
    {
        if (!GameManager.instance.bGamePaused)
        {
            soundFX.clip = gameOverClip;
            soundFX.Play();
        }
    }
}
