using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnStart;
    public float spawnWait;
    public float waveWait;

    public Text scoreText;
    //public GUIText restartText;
    public Text gameOverText;
    public GameObject restartButton;
    public GameObject exitButton;

    private int score;
    private bool gameOver;
    //private bool restart;

    void Start () {
        gameOver = false;
        //restart = false;
        //restartText.text = "";
        restartButton.SetActive(false);
        gameOverText.text = "";
        exitButton.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
	}

    /*void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().path);
            }
        }
    }*/

    IEnumerator SpawnWaves () {
        yield return new WaitForSeconds(spawnStart);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                //restartText.text = "Press 'R' to restart game.";
                restartButton.SetActive(true);
                exitButton.SetActive(true);
                //restart = true;
                break;
            }
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
