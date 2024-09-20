using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesActivation : MonoBehaviour
{
    public GameObject notaVisual;
    private bool activa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activa == true)
        {
            notaVisual.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && activa == true)
        {
            notaVisual.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            activa = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            activa = false;
            notaVisual.SetActive(false);
        }
    }

}
