using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPorContacto : MonoBehaviour
{

    public GameObject explosion,playerExplosion;
    private int puntaje= 10;
    private GameController gamecontroller;

    private void Start()
    {
        gamecontroller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag != "limite")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            Destroy(Instantiate(explosion, transform.position, transform.rotation),3);
            if (other.CompareTag("Player"))
            {
                Destroy(Instantiate(playerExplosion, other.transform.position, other.transform.rotation),2);
            }
            else
            {
                Debug.Log("DestruirPorCOntacto: entra "+puntaje);
                gamecontroller.addScore(puntaje); 
            }
            
        }
    }
}
