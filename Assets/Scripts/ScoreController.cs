using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public int score;

    public int wave = 1;
    public float timeLeft = 30;
    public Text timerText;
    public Text waveText;
    public Text scoreText;


    public void Update()
    {


    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = "SCORE: " + score.ToString();

    }

}
