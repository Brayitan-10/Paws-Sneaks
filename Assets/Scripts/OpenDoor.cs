using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public GameObject puerta;
    public Transform puntoA, puntoB;
    public float velocidad = 2f;

    private bool puertaAbierta = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puertaAbierta = true;
        }
    }

    void Update()
    {
        if (puertaAbierta)
        {
            puerta.transform.position = Vector3.MoveTowards(puerta.transform.position, puntoB.position, velocidad * Time.deltaTime);

            if (Vector3.Distance(puerta.transform.position, puntoB.position) < 0.1f)
            {
                puertaAbierta = false;
                puerta.transform.position = puntoB.position;
            }
        }
    }
}