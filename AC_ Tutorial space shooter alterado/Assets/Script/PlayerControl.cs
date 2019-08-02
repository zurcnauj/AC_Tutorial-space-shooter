 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, ymin, ymax;

    
}


public class PlayerControl : MonoBehaviour
{
    [Header("movimiento")]
    public float velocidad;
    private Rigidbody rig;
    public Boundary boundary;
    private float mov_horizontal;
    private float mov_vertical;
    private Vector3 movement;

    [Header("disparo")]
    public float tazadisparo = 1;
    public GameObject disparo;
    public Transform zonaDisparo;
    private bool disparar;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        mov_horizontal = Input.GetAxis("Horizontal");
        mov_vertical = Input.GetAxis("Vertical");

        disparar = Input.GetKeyDown(KeyCode.Space);
        
    }

    private void FixedUpdate()
    {
      

        movement = new Vector3(mov_horizontal, 0, mov_vertical);
        rig.velocity = movement * velocidad;
        rig.position = new Vector3( Mathf.Clamp(rig.position.x, boundary.xmin,boundary.xmax),0,Mathf.Clamp(rig.position.z, boundary.ymin,boundary.ymax));
        rig.rotation = Quaternion.Euler(0, 0, mov_horizontal*25);

        if (disparar)
        {
            disparar = false;

            Instantiate(disparo, zonaDisparo.position, zonaDisparo.rotation);
        }
    }
}
