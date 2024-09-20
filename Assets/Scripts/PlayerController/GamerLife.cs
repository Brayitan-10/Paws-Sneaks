using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamerLife : MonoBehaviour
{
    [SerializeField] int life, maxLife = 100;
    public UnityEvent<int> cambioVida;
    Vector2 startPosition;
    void Start()
    {
        life = maxLife;
        startPosition = transform.position;
        //cambioVida.Invoke(life);
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life < 0)
        {
            //Destroy(gameObject);
            DiePlayer();
        }

        //cambioVida.Invoke(life);
    }
    void DiePlayer()
    {
        RespawnPlayer();
        Life();
    }
    void RespawnPlayer()
    {
        transform.position = startPosition;
    }
    public void Life()
    {
        life = 100;
    }
    //public void Cure(int healing)
    //{
    //    if ((life + healing) > maxLife)
    //    {
    //        life = maxLife;
    //    }
    //    else
    //    {
    //        life += healing;
    //    }
    //}
}