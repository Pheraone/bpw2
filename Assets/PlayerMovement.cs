using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement instance;
    public static PlayerMovement Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerMovement>();

            return instance;
        }
    }

    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    Vector2 movement;
    //public CloseDoors closingDoor;

    private void Start()
    {
       
            
    }

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("player collided with " + collider.name);
        CloseDoors.ClosingDoors.ActivateDoors(true);
      
    }

}

