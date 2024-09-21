using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    public GameObject puerta;
    public Transform puntoA;
    public Transform puntoB;
    public GameObject tecladoPanel;
    public Button[] botones;
    public int[] codigoSecreto = { 7, 8, 3, 1, 4, 5 };
    private int indiceCodigo = 0;
    private bool codigoCorrecto = false;
    public float velocidadMovimiento = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tecladoPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tecladoPanel.SetActive(false);
            indiceCodigo = 0;
            //codigoCorrecto = false;
        }
    }
    public void PresionarBoton(int valorBoton)
    {
        if (valorBoton == codigoSecreto[indiceCodigo])
        {
            indiceCodigo++;
            if (indiceCodigo == codigoSecreto.Length)
            {
                codigoCorrecto = true;
            }
        }
        else
        {
            indiceCodigo = 0;
            codigoCorrecto = false;
        }
    }
    void Update()
    {
        if (codigoCorrecto)
        {
            puerta.transform.position = Vector2.MoveTowards(puerta.transform.position, puntoB.position, velocidadMovimiento * Time.deltaTime);
        }
        else
        {
            puerta.transform.position = Vector2.MoveTowards(puerta.transform.position, puntoA.position, velocidadMovimiento * Time.deltaTime);
        }
    }
}