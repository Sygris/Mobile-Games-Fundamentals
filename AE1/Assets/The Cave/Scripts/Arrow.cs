using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.right * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<UsefulScript>().KillPlayer();
        }

        if (collision.gameObject.CompareTag("Boundarie") || collision.gameObject.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
    }
}
