using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    public int points;
    Vector2 movement;
    public int currentHealth;
    public int maxPoints;

    private void Start()
    {
        maxPoints = LevelGeneration.LevelGenerator.numberOfChambers;
        points = 0;
    }

    void Update()
    {
        //input
        movement.x  = Input.GetAxisRaw("Horizontal");
        movement.y  = Input.GetAxisRaw("Vertical");
        
        //check if player is out of health
        if(currentHealth <= 0)
        {
            Dead();
        }

        //checks if player gets all points in level, generates new level if the player does
        if (points >= maxPoints)
        {
            points = 0;
            LevelGeneration.LevelGenerator.GenerateNewLevel();
        } 
    }
    
    //Player gets damage from whatever gives damage 
    public void GetDamage(int damage)
    {
       currentHealth = currentHealth - damage;
    }

    //if player is dead calls the lose state
    public void Dead()
    {
        GameManager.Instance.fsm.GotoState(GameStateType.Lose);
        AudioHandler.AudioHandle.StopTheMusic();
    }

    //50 times a second
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "DoorTrigger")
        {
            //closes doors if player steps in the room
            DoorsBehaviour.ClosingDoors.ActivateDoors(true);
            //destorys collider so that the room will remain open if player steps in again
            Destroy(collider.GetComponent<BoxCollider2D>());
        }

    
    }

}

