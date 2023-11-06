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
    public float dashPower = 2f;    //min dash power is 2 and max is 6
    public float maxDashPower = 6f; //max dash power
    public ParticleSystem dashFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashFX.Stop();
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
    private void LateUpdate()
    {
        MakeDashEffect();
    }

    //HANDLING FUNCTIONS
    void GetInput()
    {
        //Player movement inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Prevent the player move faster when going diagonally
        DiagonalMove = new Vector3(movement.x, movement.y).normalized;

        //When the Space key is held down and the current dash power is smaller than the dash power
        if (Input.GetKey(KeyCode.Space) && dashPower < maxDashPower)
        {
            dashPower = dashPower += Time.deltaTime;
            Debug.Log(dashPower);
           // DashEffect();
        }
        
        //When the SPACE key is released, set isDashButtonDown to true
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isDashButtonDown = true;
            dashFX.Stop();
        }

        /* If the current dash power is bigger or equal to the max dash power
        then set the isDashButtonDown boolean to false and set the power back to 2 */
        if (dashPower >= maxDashPower)
        {
            isDashButtonDown = false;
            dashPower = 2f;
        }
    }


    void Dash()
    {
        /* If SPACE is released
        Move the player to the target then set the isDashButtonDown boolean to false */
        if (isDashButtonDown)
        {
            rb.MovePosition(transform.position + movement * dashPower);
            isDashButtonDown = false;
        }
    }
    void Sprint()
    {
        /*If Left SHIFT is held down and the energy bar has energy
        The movespeed of the player will be set to 10 */
        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 6f;
        }
    }
    void DashEffect()
    {
        Instantiate(dashFX, this.transform.position, Quaternion.identity);
        dashFX.Play();
    }

    void MakeDashEffect()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            dashFX.Play();
        }
    }

}
