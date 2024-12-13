using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    /*Esta clase destruye cualquier objeto que salga del area definida por un collider configurado como Trigger
    * En pocas palabras nos ayuda a quitar los objetos redundantes en la escena.
    */
    void OnTriggerExit(Collider other) 
    {
        Destroy(other.gameObject);
    }
}
