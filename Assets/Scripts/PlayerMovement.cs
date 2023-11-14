using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    HermesBoots hermesBootsScript;
    DashStamina dashStaminaScript;

    public float moveSpeed, dashBoostSpeed;
    public Rigidbody2D rb;
    Vector3 movement;
    Vector2 targetPos;
    Vector3 DiagonalMove;
    public bool canSprint;

    public bool isDashButtonDown, isReleasedDash;
    public bool hasFinishedDashing;
    public float dashPower = 2f;    //min dash power is 2 and max is 6
    public float maxDashPower = 6f; //max dash power

    [SerializeField] private float dashBoostSpeedDuration;

    

    private void Start()
    {
        hermesBootsScript = FindObjectOfType<HermesBoots>();
        dashStaminaScript = FindObjectOfType<DashStamina>();
        rb = GetComponent<Rigidbody2D>();
 
        canSprint = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Handle inputs
        GetInput();

        //Player's speed after picking up the hermes boots
        HermesBootsPicking();
    }
    void FixedUpdate()
    {
        //Handle movements stuff 
        rb.velocity = movement * moveSpeed;
        Dash();
        Sprint();
        BoostSpeedAfterDashing();
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
            moveSpeed = 6f;
            isDashButtonDown = true;
            isReleasedDash = false;
            dashPower = dashPower += Time.deltaTime;
            hasFinishedDashing = false;
        }
        
        //When the SPACE key is released, set isDashButtonDown to false
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isDashButtonDown = false;
            isReleasedDash = true;
            hasFinishedDashing = true;
            dashStaminaScript.startSubtractingStamina = true;

        }
        /* If the current dash power is bigger or equal to the max dash power
        then set the isDashButtonDown boolean to false and set the power back to 2 */
        if (dashPower >= maxDashPower)
        {
            dashPower = 2f;
        }
    }


    void Dash()
    {
        /* If SPACE is released
        Move the player to the target */
        if (!isDashButtonDown && isReleasedDash)
        {
            //rb.MovePosition(transform.position + movement * dashPower);   
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos, dashPower );
        }
    }
    void Sprint()
    {

        /*If Left SHIFT is held down and the energy bar has energy
        The movespeed of the player will be set to 10 */
        if(Input.GetKey(KeyCode.LeftShift) && canSprint) 
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 6f;
        }
    }
    void HermesBootsPicking()
    {
        if(hermesBootsScript.HermesBootsPickedUp)
        {
            moveSpeed = hermesBootsScript.currentSpeed;
            canSprint = false;
        }
    }
    void BoostSpeedAfterDashing()
    {
        //When the player is not holding down 
        //and released the dash button
        if (hasFinishedDashing)
        {
            moveSpeed += dashBoostSpeed;
            dashBoostSpeedDuration = dashBoostSpeedDuration -= Time.deltaTime;

            if (dashBoostSpeedDuration <= 0)
            {
                hasFinishedDashing = false;
                dashBoostSpeedDuration = 2.5f;
            }
        }
    }
}
