using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPlataform : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float returnTimePlataform;

    private Rigidbody2D rb2D;

    [SerializeField] private float rotationVelocity;

    private Animator animator;
    private bool fall = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (fall)
        {
            transform.Rotate(new Vector3(0, 0, rotationVelocity * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall(other));
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Fall(Collision2D other)
    {
        yield return new WaitForSeconds(waitTime);
        fall = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.AddForce(new Vector2(0.1f, 0));
    }
}