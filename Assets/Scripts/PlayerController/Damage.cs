using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*public class Damage : MonoBehaviour
{
    [SerializeField] private float timeEnterDamage;

    private float timeNextDamage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            timeNextDamage -= Time.deltaTime;
            if (timeNextDamage <= 0)
            {
                other.gameObject.GetComponent<DeadPlayer>().Damage1(100);
                timeNextDamage = timeEnterDamage;
            }
        }
    }
}*/