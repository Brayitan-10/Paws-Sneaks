using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patrullague : MonoBehaviour
{

    public int movi;
    public float crono;
    public Animator animator;
    public int direccion;
    public float speedcaminar;
    public float speedcorrer;
    public GameObject target;
    public bool ataque;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento()
    {
        animator.SetBool("correr", false);
        crono += 1 * Time.deltaTime;
        if (crono >= 4)
        {
            movi = Random.Range(0, 2);
            crono = 0;
        }

        switch (movi)
        {
            case 0:
                animator.SetBool("caminar", false);
                break;

            case 1:
                direccion = Random.Range(0, 2);
                movi++;
                break;
            case 2:
                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speedcaminar * Time.deltaTime);
                        break;


                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speedcaminar * Time.deltaTime);
                        break;


                }
                animator.SetBool("caminar", true);
                break;



        }
    }
    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }
}
