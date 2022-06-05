using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;
    public Text throwForceText;

    int score = 0;
    int highScore = 0;
    int throwForce = 20;

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
    private void Update()
    {
        throwForceText.text = "Throw Force: " + throwForce.ToString();
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            throwForce++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            throwForce--;
        }
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
