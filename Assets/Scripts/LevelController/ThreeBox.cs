using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeBox : MonoBehaviour
{
    public GameObject puerta;
    public Transform puntoA, puntoB;
    public GameObject boton1, boton2, boton3;
    private bool boton1Presionado = false;
    private bool boton2Presionado = false;
    private bool boton3Presionado = false;
    public float velocidadMovimiento = 2f;

    void Update()
    {
        boton1Presionado = Physics2D.OverlapCircle(boton1.transform.position, 0.1f);
        boton2Presionado = Physics2D.OverlapCircle(boton2.transform.position, 0.1f);
        boton3Presionado = Physics2D.OverlapCircle(boton3.transform.position, 0.1f);

        if (boton1Presionado && boton2Presionado && boton3Presionado)
        {
            puerta.transform.position = Vector2.MoveTowards(puerta.transform.position, puntoB.position, velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            puerta.transform.position = Vector2.MoveTowards(puerta.transform.position, puntoA.position, velocidadMovimiento * Time.deltaTime);
        }
    }
}