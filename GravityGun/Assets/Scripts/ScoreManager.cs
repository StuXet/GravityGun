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

    int _score = 0;
    int _highScore = 0;
    int _throwForce = 20;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Gets the last high score that was saved on player prefs
        _highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = _score.ToString() + " Points";
        highScoreText.text = "HighScore: " + _highScore.ToString();
    }
    private void Update()
    {
        //Updates the throw force in the UI
        throwForceText.text = "Throw Force: " + _throwForce.ToString();
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            _throwForce++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _throwForce--;
        }
    }

    public void AddPoint()
    {
        //Update and add +1 point to the UI. if high score smaller than current score, it updates the high score
        _score += 1;
        scoreText.text = _score.ToString() + " Points";
        if(_highScore < _score)
           PlayerPrefs.SetInt("highscore", _score);
    }

    public void RemovePoints()
    {
        //Update and remove -1 point from the UI. if high score smaller than current score, it updates the high score
        _score -= 1;
        scoreText.text = _score.ToString() + " Points";
        if (_highScore < _score)
            PlayerPrefs.SetInt("highscore", _score);
    }
}
