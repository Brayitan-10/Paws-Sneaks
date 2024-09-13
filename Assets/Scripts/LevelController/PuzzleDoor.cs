using UnityEngine;
using UnityEngine.UI;



public class PuzzleDoor : MonoBehaviour
{
    public GameObject puerta;
    public Transform puntoA, puntoB;
    public float velocidad = 2f;

    public GameObject palancaA, palancaB, palancaC, palancaD, palancaE;

    private bool palancaBActiva = false;
    private bool palancaCActiva = false;
    private bool palancaDActiva = false;
    private bool puertaAbierta = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject palanca = collision.gameObject;

            if (palanca == palancaA)
            {
                palancaBActiva = false;
            }
            else if (palanca == palancaC)
            {
                palancaDActiva = false;
            }
            else if (palanca == palancaE)
            {
                palancaCActiva = false;
            }
            else if (palanca == palancaB)
            {
                palancaBActiva = true;
            }
            else if (palanca == palancaC)
            {
                palancaCActiva = true;
            }
            else if (palanca == palancaD)
            {
                palancaDActiva = true;
            }

            if (palancaBActiva && palancaCActiva && palancaDActiva)
            {
                puertaAbierta = true;
            }
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
    }
}