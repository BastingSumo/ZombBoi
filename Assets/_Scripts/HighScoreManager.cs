using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    static HighScoreManager instance;
    public static HighScoreManager Instance { get { return instance; } }

    int currentScore = 0;
    int highScore = 0;

    [SerializeField] TextMeshProUGUI highScoreUI;
    [SerializeField] TextMeshProUGUI currentScoreUI;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    private void Update()
    {
        ManageHighScore();
        ManageScoreUI();
    }
    void ManageHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
    }
    void ManageScoreUI()
    {
        highScoreUI.text = " High Score : " + highScore.ToString();
        currentScoreUI.text = " Current Score : " + currentScore.ToString();
    }
    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
    public void IncreaseHighScore(int increaseAmount)
    {
        currentScore += increaseAmount;
    }
    public void ResetCurrentScore()
    {
        currentScore = 0;
    }
}
