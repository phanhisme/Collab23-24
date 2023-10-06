using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;

    [Header("Dashing Stuff")]
    public float dashSpeed = 10f;
    public float dashDuration = 1f;
    public float dashCooldown = 1f;
    public bool isDashing = false;
    public bool canDash;
    public ParticleSystem particles;
    private void Start()
    {
        canDash = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Can't do anything while dashing
        if (isDashing)
        {
            return;
        }
        //Handle inputs
        GetInput();
    }
    void FixedUpdate()
    {
        //Handle movements stuff 
        GetMovement();
    }


    //FUNCTIONS
    void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    void GetMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        canDash = true;
    }


}
