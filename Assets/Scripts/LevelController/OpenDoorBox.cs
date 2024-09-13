using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorBox : MonoBehaviour
{
    public GameObject puerta;
    public Transform puntoA, puntoB;
    public float velocidad = 2f;

    private bool puertaAbierta = false;
	private bool puertaCerrada = false;

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            puertaAbierta = true;
            Debug.Log("puerta abierta");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.CompareTag("Box"))
		{
			puertaCerrada = true;
			Debug.Log("puerta CERRADA");
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
		else if (puertaCerrada)
		{
			puerta.transform.position = Vector3.MoveTowards(puerta.transform.position, puntoA.position, velocidad * Time.deltaTime);
			if (Vector3.Distance(puerta.transform.position, puntoA.position) < 0.1f)
			{
				puertaAbierta = false;
				puerta.transform.position = puntoA.position;
			}
		}
	}
	/*private void OnTriggerExit2D(Collider2D collision)
    {
		puertaAbierta = false;
	}*/

}