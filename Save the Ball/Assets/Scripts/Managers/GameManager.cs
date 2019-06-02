using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private GameObject goGameOverMenuUI;

    public int iLevel = 1;
    public int iNumberOfLevels = 10;

    public bool bReverseMovement = false;

    public bool bGamePaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        iLevel = (PlayerPrefs.GetInt("level") > 0 ? PlayerPrefs.GetInt("level") : 1);
        levelText.text = "Level " + iLevel.ToString();
    }

    public void LevelPassed()
    {
        iLevel = (iLevel == iNumberOfLevels ? iLevel : iLevel + 1);
        PlayerPrefs.SetInt("level", iLevel);

        levelText.text = "Level " + iLevel.ToString();

        Invoke("LoadGameplay", 0.5f);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        bGamePaused = false;

        LoadGameplay();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        bGamePaused = true;

        goGameOverMenuUI.SetActive(true);
    }

    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
