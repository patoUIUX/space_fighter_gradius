using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public bool explosionInstantiated = false;

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        //GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Boundary")) return;

        if (explosionInstantiated == false)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("Intancie una asteroid explosion");
            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
                Debug.Log("Intancie una player explosion");
            }

            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);

            explosionInstantiated = true;
        }
        
    }
}
