using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    /*
     * Esta es la clase principal del juego, donde estaremos manejando los comportamientos centrales: 
     * generacion de asteroider, control de oleadas y sistema de puntuacion.
     */

    //Estas variable a continuacion son las que nos ayudan a que haya asteroides y tengan cierto comportamiento.
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //Con estas, estaba empezando a estructurar el sistema de puntuacion.
    public TMP_Text scoreText;
    private int score;

    //Con estas, estaba manejando la gestion del estado del juego.
    public TMP_Text restartText;
    public TMP_Text gameOverText;
    private bool restart;
    private bool gameOver;

    //Y por ultimo con esta estaba llevando la cuenta del numero de oleadas.
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

    //Con la siguiente corrutina generamos oleadas de obstaculos.

    /* 
     *Iniciamos en un tiempo definido con el startWait para luego iniciar un bucle (por ahora infinito) que nos indique los numeros de oleadas
     * Si el estado de Game Over = true, entonces nos muestra texto de re-iniciar.
     */
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(spawnWait);
        while (true)
        {
            // Incrementar el número de wave y mostrar en consola (por ahora).
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
