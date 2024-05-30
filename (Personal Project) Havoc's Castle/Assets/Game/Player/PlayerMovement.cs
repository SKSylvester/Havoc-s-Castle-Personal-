using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D player;
    public float playerSpeed = 5.0f;
    public float jumpForce = 8.0f;
    private bool isGrounded;
 

    // Layer to determine what is ground
    public LayerMask groundLayer; //check if layers are overlapping
    public Transform groundCheck; //Object to check the ground
    public float groundCheckRadius = 0.2f; //Ground checkers radius

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // Get 2D component Rigid Body
    }



    // Update is called once per frame
    void Update()
    {
        //Horizontal movement to player

        float horizontalInput = Input.GetAxis("Horizontal");

        player.velocity = new Vector2(horizontalInput * playerSpeed, player.velocity.y);

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //Components to check if the player is on the ground.
         
        if (isGrounded && Input.GetButtonDown("Jump"))         // If the player is on the floor and presses the jump button
        {

            player.velocity = new Vector2(player.velocity.x, jumpForce); // add the jump force to the Rigid body's y axis.

            Debug.Log("Player Has jumped" + player.velocity);
        }
        
    }
}
