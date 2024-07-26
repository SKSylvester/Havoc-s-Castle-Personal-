using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Battle : MonoBehaviour
{
    public Rigidbody2D player;
    public int health; 
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("Attack");
            animator.SetBool("isAttacking1", true);
        }
    }
    void FixedUpdate()
    {

    }
}
