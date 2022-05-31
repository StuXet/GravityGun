using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";
        if(highScore < score)
        PlayerPrefs.SetInt("highscore", score);
    }

    public void RemovePoints()
    {
        score -= 1;
        scoreText.text = score.ToString() + " Points";
        if (highScore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
}
