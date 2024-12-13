using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    /*Con esta clase ayudamos a nuestros asteroides a rotar de forma aleatoria, 
     * este script tomaria mucha mas relevancia sustituyendo los asteroides placeholder por unos con texturas 
     * y efectos visuales que le den valor al hecho de que el objeto se este moviendo.
     */

    public float tumble;
    private Rigidbody rig;

    void Awake() 
    
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rig.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
