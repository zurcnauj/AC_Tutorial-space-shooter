using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_controller : MonoBehaviour
{
    public float velocidad;

    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rig.angularVelocity = Random.insideUnitSphere * velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
