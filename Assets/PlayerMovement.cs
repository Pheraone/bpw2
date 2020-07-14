using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        //input
        movement.x  = Input.GetAxisRaw("Horizontal");
        movement.y  = Input.GetAxisRaw("Vertical");
    }

    //50 times a second
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
