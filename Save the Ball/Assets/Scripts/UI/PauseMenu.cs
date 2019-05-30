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
        UnfreezeGame();
    }

    public void Pause()
    {
        this.gameObject.SetActive(true);
        FreezeGame();
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

    public void FreezeGame()
    {
        Time.timeScale = 0.5f;
        GameManager.instance.bGamePaused = true;
    }

    public void UnfreezeGame()
    {
        Time.timeScale = 1f;
        GameManager.instance.bGamePaused = false;
    }
}
