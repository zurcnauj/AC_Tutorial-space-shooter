using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LimitesMapa
{
    public float lx_izq, lx_der, ly_sup, ly_inf;

}

public class Nave_jugador : MonoBehaviour
{
    [Header("LimitesMapa")]
    public LimitesMapa mapa;

    [Header("movimiento")]
    public float velocidad;
    private float movimiento_horizontal, movimiento_vertical;

    //vector para la velocidad
    private Vector3 vector_velocidad;

    // rigibody de la nave
    private Rigidbody nave;

    private void Awake()
    {
        nave = GetComponent<Rigidbody>();
        //mapa = new LimitesMapa();
        vector_velocidad = new Vector3(0, 0, 0);
    }

    void Update()
    {
        movimiento_horizontal = Input.GetAxis("Horizontal");
        movimiento_vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        acomodarVerctorVelocidad();
        nave.velocity = vector_velocidad * velocidad;
        transform.rotation = Quaternion.Euler(-90, movimiento_horizontal * 15, 0);
    }

    private void acomodarVerctorVelocidad( )
    {
       if(movimiento_horizontal < 0 )
        {
           if(transform.position.x < mapa.lx_izq)
            {
                vector_velocidad.x = 0;
            }
            else
            {
                vector_velocidad.x = movimiento_horizontal;
            }
        }
        else
        {
            if (transform.position.x >= mapa.lx_der)
            {
                vector_velocidad.x = 0;
            }
            else
            {
                vector_velocidad.x = movimiento_horizontal;
            }
        }

        if (movimiento_vertical < 0)
        {
            if (transform.position.y <= mapa.ly_inf)
            {
                vector_velocidad.y = 0;
            }
            else
            {
                vector_velocidad.y = movimiento_vertical;
            }
        }
        else
        {
            if (transform.position.y >= mapa.ly_sup)
            {
                vector_velocidad.y = 0;
            }
            else
            {
                vector_velocidad.y  = movimiento_vertical;
            }
        }
    }

}
