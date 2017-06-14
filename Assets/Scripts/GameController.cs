﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int wave = 1;
    public int score = 0;
    public float timer = 60;
    public int hits = 0;
    public int shotsFired = 0;
    public int goalHits = 0;
    public Canvas InstructionCanvas;
    public Text PlayerScoreText;
    public Text PlayerTimerText;
    public Text PlayerWaveText;
    public Text PlayerRatio;
    public Text InstructionsWaveText;
    public Text InstructionsText;
    public bool IsRunning = false;
    public GameObject PlaneSpawnPoint;

    public AudioSource Siren;


    private float zOriginalLocation;
    private float zHiddenLocation = 1000;

    
	// Use this for initialization
	void Start () {

        zOriginalLocation = InstructionCanvas.transform.position.z;

        this.Show();

	}
	
	// Update is called once per frame
	void Update () {

        if (!IsRunning)
        {
            string txt = "";
            switch (wave)
            {
                case 1:
                    txt = "Shoot down 10 fighters in 60 seconds!";
                    hits = 0;
                    goalHits = 10;
                    timer = 60;
                    PlaneSpawnPoint.GetComponent<EnemyGenerator>().spawnMin = 1;
                    PlaneSpawnPoint.GetComponent<EnemyGenerator>().spawnMax = 1;
                    break;
                case 2:
                    txt = "Shoot down 15 fighters in 60 seconds!";
                    hits = 0;
                    goalHits = 15;
                    timer = 60;
                    PlaneSpawnPoint.GetComponent<EnemyGenerator>().spawnMin = 1;
                    PlaneSpawnPoint.GetComponent<EnemyGenerator>().spawnMax = 3;
                    break;
                case 3:
                    txt = "Shoot down 10 fighters in 45 seconds!";
                    hits = 0;
                    goalHits = 20;
                    timer = 60;
                    PlaneSpawnPoint.GetComponent<EnemyGenerator>().spawnMin = 2;
                    PlaneSpawnPoint.GetComponent<EnemyGenerator>().spawnMax = 5;
                    break;
            }

            InstructionsText.text = txt;
            InstructionsWaveText.text = "Wave " + wave;

            if (Input.GetButton("Fire1"))
            {
                // Hide the instruction canvas
                this.Hide();
            }
        }
        else
        {
            timer -= Time.deltaTime;
            int t = Convert.ToInt32(Mathf.Round(timer));
            PlayerTimerText.text = "Time:" + t;
            PlayerScoreText.text = "Score:" + score;
            PlayerWaveText.text = "Wave " + wave;
            PlayerRatio.text = hits + "/" + goalHits;
            

            if (t == 0)
            {
                wave++;
                timer = 60;
                this.Show();
            }

        }
		
	}

    public void Show()
    {
        Vector3 pos = InstructionCanvas.transform.position;
        pos.z = zOriginalLocation;
        InstructionCanvas.transform.position = pos;
        InstructionCanvas.GetComponent<AudioSource>().Play();
        IsRunning = false;

        Siren.Stop();
    }

    public void Hide()
    {
        Vector3 pos = InstructionCanvas.transform.position;
        pos.z = zHiddenLocation;
        InstructionCanvas.transform.position = pos;
        InstructionCanvas.GetComponent<AudioSource>().Stop();
        IsRunning = true;

        Siren.Play();
    }

}