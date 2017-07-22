﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject[] powerUps;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnStart;
    public float spawnWait;
    public float waveWait;
    public float powerUpOdd;

    public GUIText scoreText;
    public GUIText levelText;
    public GUIText restartText;
    public GUIText gameOverText;

    private int score;
    private int scoreMultiplicator;
    private int levelNumber;
    private bool gameOver;
    private bool restart;

    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        scoreMultiplicator = 1;
        levelNumber = 1;
        UpdateScore();
        UpdateLevel();
        StartCoroutine (SpawnWaves());
	}

    void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().path);
            }
        }
    }

    IEnumerator SpawnWaves () {
        yield return new WaitForSeconds(spawnStart);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                // enemy spawn
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                // power up spawn
                if (Random.value <= powerUpOdd)
                {
                    GameObject powerUp = powerUps[Random.Range(0, powerUps.Length)];
                    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Instantiate(powerUp, spawnPosition, spawnRotation);
                }
                 
                yield return new WaitForSeconds(spawnWait);
            }

            if (gameOver)
            {
                restartText.text = "Press 'R' to restart game.";
                restart = true;
                break;
            }

            // less chance for power ups each wave
            //powerUpOdd -= 0.05f;
            yield return new WaitForSeconds(waveWait);
            levelNumber++;
            UpdateLevel();
        }
    }
    
    public void IncreaseScoreMultiplicator(int multiplicator)
    {
        // TODO: make animation for double points
        scoreMultiplicator *= multiplicator;
    }

    public void DecreaseScoreMultiplicator(int multiplicator)
    {
        scoreMultiplicator = Mathf.Max(1, scoreMultiplicator/multiplicator);
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue * scoreMultiplicator;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLevel()
    {
        levelText.text = "Level: " + levelNumber;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
