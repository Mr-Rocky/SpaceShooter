using System.Collections;
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
    public GUIText restartText;
    public GUIText gameOverText;

    private int score;
    private bool gameOver;
    private bool restart;

    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
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
                if (powerUpOdd <= Random.value)
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

            yield return new WaitForSeconds(waveWait);
        }
    }
    

    /// <summary>
    /// Increses the score by the given value.
    /// </summary>
    /// <param name="newScoreValue">The new score value.</param>
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
