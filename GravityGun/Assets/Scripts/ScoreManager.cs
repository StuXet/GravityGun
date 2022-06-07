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
        //Gets the last high score that was saved on player prefs
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "HighScore: " + highScore.ToString();
    }
    private void Update()
    {
        //Updates the throw force in the UI
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
        //Update and add +1 point to the UI. if high score smaller than current score, it updates the high score
        score += 1;
        scoreText.text = score.ToString() + " Points";
        if(highScore < score)
           PlayerPrefs.SetInt("highscore", score);
    }

    public void RemovePoints()
    {
        //Update and remove -1 point from the UI. if high score smaller than current score, it updates the high score
        score -= 1;
        scoreText.text = score.ToString() + " Points";
        if (highScore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
}
