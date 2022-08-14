using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{

    public float speed = 30f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        rb.velocity = speed * direction * Vector2.right;

    }
}
