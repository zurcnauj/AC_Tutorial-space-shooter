using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
   
    public float velocidad;
    private Rigidbody rig;

    

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rig.velocity = new Vector3(0,0,velocidad);
    }
}
