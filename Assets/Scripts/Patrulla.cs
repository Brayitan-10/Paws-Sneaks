using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform caida;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimiento;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infosuelo = Physics2D.Raycast(caida.position, Vector2.down, distancia);
        rb.velocity = new Vector2(velocidad,rb.velocity.y);

        if(infosuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        movimiento = !movimiento;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(caida.transform.position, caida.transform.position + Vector3.down * distancia);
    }
}
