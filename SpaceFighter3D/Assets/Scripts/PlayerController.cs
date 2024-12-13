using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    //Esta es otra clase pero nos ayuda a determinar los limites en que nuestro player se mueve.
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    //Esta clase nos ayuda a gestionar a nuestro player, nos ayuda con el movimiento, disparos y limitaciones en las que se movera nuestra nave.

    /*
     * Aca separe e hice una especie de subtitulos para que en el inspector pudiera verse un poco mas organizado, 
     * categorice las variables por: movimiento, disparo y audio.
     */

    //1. Movimiento
    [Header("Movement")]
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rig;

    //2. Disparo
    [Header("Shooting")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    //3. Audio
    private AudioSource audioSource;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    //En este Update gestionamos los disparos, se que el update no es lo mas eficiente pero por el momento lo estaba manejando de esta manera.
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            audioSource.Play();
        }
    }

    /*Aca gestionamos el movimiento del player, no solo de izquierda a derecha, al frente y atras,
    *sino que tambien le dimos una rotacion sutil a nuestra nave para que a futuro el modelo 3D se vea mejor.
    */
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x,boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}