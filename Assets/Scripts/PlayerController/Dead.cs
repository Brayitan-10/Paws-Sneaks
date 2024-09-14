using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private float timeBetweenDamage;

    private float timeNextDamage;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            timeNextDamage -= Time.deltaTime;
            if (timeNextDamage <= 0)
            {
                other.gameObject.GetComponent<GamerLife>().TakeDamage(200);
                timeNextDamage = timeBetweenDamage;
            }
        }
        //if (other.collider.CompareTag("Player"))
        //{
        //    other.GetComponent<GamerLife>().TakeDamage
        //}
    }
}