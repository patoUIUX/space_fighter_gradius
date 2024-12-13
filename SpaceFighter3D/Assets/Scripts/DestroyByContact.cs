using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    //Esta clase gestiona las interacciones entre objetos que tienen un collider con la opcion isTrigger.

    //Estas variables me ayudan con el instanciado de las explosiones
    public GameObject explosion;
    public GameObject playerExplosion;
    public bool explosionInstantiated = false;

    //Con esta variable gestionamos el valor del score.
    public int scoreValue;
    //Esta variable referencia a nuestra clase GameController.
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
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
