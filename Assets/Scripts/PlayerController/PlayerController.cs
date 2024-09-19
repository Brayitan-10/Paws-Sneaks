using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform play;
    public float speed, axisHorizontal, runSpeed, jumpForce;
    public Rigidbody2D rigidBodyPlayer;
    private bool onGround = true;
    float x = 180f, a = -360f;
    public Animator animator;

    //public ParticleController1 particleController;
    private void Awake()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }
    void Update()
    {
        axisHorizontal = Input.GetAxis("Horizontal");

       // animator.SetFloat("Movement"),speed;

        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            rigidBodyPlayer.AddForce(Vector2.up * jumpForce);
            onGround = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            play.SetPositionAndRotation(transform.position, transform.rotation);
            x += Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(0, x, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            play.SetPositionAndRotation(transform.position, transform.rotation);
            a += Time.deltaTime * 10;
            transform.rotation = Quaternion.Euler(0, a, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
        onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = speed;

        // Verifica si la tecla de correr está presionada
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= runSpeed;
            animator.SetBool("Correr", true); // Usa la velocidad de correr
        }
        else
        {
            animator.SetBool("Correr", false);
        }

        if (rigidBodyPlayer.bodyType != RigidbodyType2D.Static)
        {
            rigidBodyPlayer.velocity = new Vector2(axisHorizontal * currentSpeed, rigidBodyPlayer.velocity.y);
            animator.SetFloat("xVelocity", Math.Abs(rigidBodyPlayer.velocity.x));

        }
    }
}