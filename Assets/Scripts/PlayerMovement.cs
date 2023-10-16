using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float moveSpeed = 50f;
    public Rigidbody2D rb;
    Vector3 movement;
    Vector3 DiagonalMove;

    [Header("Dashing Stuff")]
    private bool isDashButtonDown;
    public float dashAmount = 6f;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    // Update is called once per frame
    void Update()
    {
        
        //Handle inputs
        GetInput();
    }
    void FixedUpdate()
    {
        //Handle movements stuff 
        rb.velocity = movement * moveSpeed;

        Dash();
        Sprint();
    }


    //FUNCTIONS
    void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Prevent the player move faster when going diagonally
        DiagonalMove = new Vector3(movement.x, movement.y).normalized;

        //When the player presses SPACE
        //Set the boolean to true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }
    }
    void Dash()
    {
        //If SPACE is pressed
        //Move the player to the target then set the boolean to false
        if (isDashButtonDown)
        {
            rb.MovePosition(transform.position + movement * dashAmount);
            isDashButtonDown = false;
        }
    }


    void Sprint()
    {
        //If Left SHIFT is held down and the energy bar has energy
        //The movespeed of the player will be set to 10 
        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 6f;
        }
    }
}
