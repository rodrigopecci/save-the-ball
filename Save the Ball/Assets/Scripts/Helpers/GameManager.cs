using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text highscoreText;

    public int iScore = 0;
    private int iHighscore = 0;

    public bool bReverseMovement = false;

    public bool bGamePaused = false;
    public bool bGameOver = false;

    public float fDifficultyMultiplier = 0.8f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        iHighscore = PlayerPrefs.GetInt("highscore");
        highscoreText.text = iHighscore.ToString();
    }

    public void IncrementScore()
    {
        iScore++;
        scoreText.text = iScore.ToString();
    }

    public void GameOver()
    {
        bGameOver = true;

        if (iScore > iHighscore)
        {
            PlayerPrefs.SetInt("highscore", iScore);
        }

        Invoke("LoadGameplay", 1f);
    }

    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
