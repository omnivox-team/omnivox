using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.Translate(Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Translate(Vector2.down * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Translate(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Translate(Vector2.right * speed);
        }
    }
}