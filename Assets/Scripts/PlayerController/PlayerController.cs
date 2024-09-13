using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform play;
    public float speed, axisHorizontal, jumpForce;
    public Rigidbody2D rigidBodyPlayer;
    private bool onGround = true;
    float x = 180f, a = -360f;
    public Animator animator;

    //public ParticleController1 particleController;
    private void Awake()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
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

        if (rigidBodyPlayer.bodyType != RigidbodyType2D.Static)
        {
            rigidBodyPlayer.velocity = new Vector2(axisHorizontal * speed, rigidBodyPlayer.velocity.y);

        }
    }
}