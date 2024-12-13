using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    /*Con esta clase le estoy dando un movimiento lineal hacia adelante a mis asteroides y disparos, 
     * en el futuro esta clase nos ayudaria tambien a mover los power-up, monedas, gemas
     * y objetos especiales en la partida.
     */

    public float speed;

    private Rigidbody rig;
    
    void Awake()
    {
        rig = GetComponent<Rigidbody>(); 
    }

    void Start()
    {
        rig.velocity = transform.forward * speed;
    }
}
