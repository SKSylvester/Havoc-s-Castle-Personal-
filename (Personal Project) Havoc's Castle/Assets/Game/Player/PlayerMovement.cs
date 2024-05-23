using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb2d;

    public float playerSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get 2D component Rigid Body
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement to player

        float horizontalInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontalInput, 0) * playerSpeed;
        
    }
}
