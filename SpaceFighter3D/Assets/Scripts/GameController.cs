using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public TMP_Text scoreText;
    private int score;

    public TMP_Text restartText;
    public TMP_Text gameOverText;
    private bool restart;
    private bool gameOver;

    private int waveNumber = 0;

    void Start()
    {
        restart = false;
        restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false);

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(spawnWait);
        while (true)
        {
            // Incrementar el número de oleada y mostrar en consola.
            waveNumber++;
            Debug.Log("Wave number" + waveNumber);

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore() 
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }
}
