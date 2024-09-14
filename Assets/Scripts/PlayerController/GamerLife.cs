using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerLife : MonoBehaviour
{
    [SerializeField] int life, maxLife = 100;
    Vector2 startPosition;
    void Start()
    {
        life = maxLife;
        startPosition = transform.position;
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life < 0)
        {
            //Destroy(gameObject);
            DiePlayer();
        }
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