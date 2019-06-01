using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject goHowToPlayMenuUI;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Resume()
    {
        this.gameObject.SetActive(false);

        Time.timeScale = 1f;
        GameManager.instance.bGamePaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameManager.instance.bGamePaused = true;

        this.gameObject.SetActive(true);
    }

    public void LoadHowToPlayMenu()
    {
        goHowToPlayMenuUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
