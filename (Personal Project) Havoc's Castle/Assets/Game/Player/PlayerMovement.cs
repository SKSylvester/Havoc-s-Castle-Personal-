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

    public bool facingRight = true; //Depends on if your animation is by default facing right or left


    // Layer to determine what is ground
    public LayerMask groundLayer; //check if layers are overlapping
    public Transform groundCheck; //Object to check the ground
    public float groundCheckRadius = 0.2f; //Ground checkers radius

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // Get 2D component Rigid Body
    }



    // Update is called once per frame
    void Update()
    {
         float horizontalInput = Input.GetAxisRaw("Horizontal"); //Horizontal movement to player
         player.velocity = new Vector2(horizontalInput * playerSpeed, player.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //Components to check if the player is on the ground.

        if (isGrounded && Input.GetButtonDown("Jump"))      // If the player is on the floor and presses the jump button
        {
            Debug.Log("Player is jumping");
            animator.SetBool("isJumping", true); //Set isJumping to true in the animation state
            animator.SetBool("isFalling", false); // Ensure isFalling is false when jumping

            player.velocity = new Vector2(player.velocity.x, jumpForce); // add the jump force to the Rigid body's y axis.

            Debug.Log("Player Has jumped" + player.velocity);

        }
        if (!isGrounded && player.velocity.y <= 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
            Debug.Log("Player is falling");
        }
        if (isGrounded && player.velocity.y <= 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            Debug.Log("Player has landed");
        }


    }


    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0 && !facingRight) //if the horizontal input is less than 0 the sprite is not facing right
            Flip();
        else if (horizontalInput < 0 && facingRight) //if the horizontal input is more than 0 the sprite is facing right
            Flip();
    }
   public void Flip() 
    {
        facingRight = !facingRight;
        Vector3 FlipScale = transform.localScale;
        FlipScale.x *= -1;
        transform.localScale = FlipScale;

        //This will flip the sprite if the player moves left and is facing right and will flip back if the players is facing left and moves right
    }
}