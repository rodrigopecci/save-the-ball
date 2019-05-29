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

    public float fDifficultyMultiplier = 0.5f;
    public bool bReverseMovement = false;
    public bool bGameOver;

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
