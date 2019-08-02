using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;
    public int cantAsteroides;
    public float tiempo;
    public bool activo = true;
    public float descanso = 1;

    public int puntaje;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        puntaje = 0;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        Vector3 spawnPosition = spawnValues;
        float x;
        while (activo)
        {
            for (int i = cantAsteroides; i >= 0; i--)
            {
                x = Random.Range(-6, 6);
                spawnPosition.x = x;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(tiempo);
            }
            yield return new WaitForSeconds(descanso);
        }
       
    }

    public void addScore(int ca)
    {
        puntaje += ca;
        UpdateScore();
        Debug.Log("GameController: ca: "+ca+" puntaje: "+ puntaje);
    }

    private void UpdateScore()
    {
        scoreText.text = puntaje + "";
    }
}
