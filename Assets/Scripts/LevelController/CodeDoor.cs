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
    public int codigoCorrecto = 783145; // C�digo correcto para abrir la puerta

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
                Debug.Log("C�digo incorrecto.");
            }
        }
        else
        {
            Debug.Log("Ingrese un c�digo v�lido.");
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