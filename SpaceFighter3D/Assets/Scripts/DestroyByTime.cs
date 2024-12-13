using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    //Esta clase destruye el objeto al que esta asociada luego de un tiempo que esta establecido en el inspector.
    
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime); 
    }
}
