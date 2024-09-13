using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeDoor : MonoBehaviour
{
    public GameObject puerta;
    public Transform puntoA, puntoB;
    public float velocidad = 2f;
    public InputField inputCodigo;
    public int codigoCorrecto = 783145; // Código correcto para abrir la puerta

    private bool puertaAbierta = false;

    public void VerificarCodigo()
    {
        int codigoIngresado;
        if (int.TryParse(inputCodigo.text, out codigoIngresado))
        {
            if (codigoIngresado == codigoCorrecto)
            {
                puertaAbierta = true;
            }
            else
            {
                Debug.Log("Código incorrecto.");
            }
        }
        else
        {
            Debug.Log("Ingrese un código válido.");
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