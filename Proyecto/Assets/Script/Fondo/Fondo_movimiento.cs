using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo_movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad;

    [Header("Posicion")]
    private Vector3 inicial, actual;

    private void Awake()
    {
        inicial = transform.position;
        actual = inicial;
    }

    private void FixedUpdate()
    {
        if(actual.y < -30)
        {
            actual = inicial;
        }
        else
        {
            actual.y -= velocidad;
        }

        transform.position = actual;
    }
}
