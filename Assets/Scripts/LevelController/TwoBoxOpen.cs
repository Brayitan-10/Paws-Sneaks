using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBoxOpen : MonoBehaviour
{
    public GameObject puerta;
    public Transform puntoA, puntoB;
    public float velocidad = 2f;

    public GameObject boton1, boton2;
    public GameObject caja1, caja2; // 

    private bool caja1EnBoton1 = false;
    private bool caja2EnBoton2 = false;
    private bool puertaAbierta = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == caja1 && collision.gameObject.transform.parent == boton1.transform)
        {
            caja1EnBoton1 = true;
        }
        else if (collision.gameObject == caja2 && collision.gameObject.transform.parent == boton2.transform)
        {
            caja2EnBoton2 = true;
        }

        if (caja1EnBoton1 && caja2EnBoton2)
        {
            puertaAbierta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == caja1 && collision.gameObject.transform.parent == boton1.transform)
        {
            caja1EnBoton1 = false;
        }
        else if (collision.gameObject == caja2 && collision.gameObject.transform.parent == boton2.transform)
        {
            caja2EnBoton2 = false;
        }

        if (!caja1EnBoton1 || !caja2EnBoton2)
        {
            puertaAbierta = false;
        }
    }

    void Update()
    {
        if (puertaAbierta)
        {
            puerta.transform.position = Vector3.MoveTowards(puerta.transform.position, puntoB.position, velocidad * Time.deltaTime);

            if (Vector3.Distance(puerta.transform.position, puntoB.position) < 0.1f)
            {
                puerta.transform.position = puntoB.position;
            }
        }
        else
        {
            puerta.transform.position = Vector3.MoveTowards(puerta.transform.position, puntoA.position, velocidad * Time.deltaTime);

            if (Vector3.Distance(puerta.transform.position, puntoA.position) < 0.1f)
            {
                puerta.transform.position = puntoA.position;
            }
        }
    }
}