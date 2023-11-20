using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    HermesBoots hermesBootsScript;
    DashStamina dashStaminaScript;

    public float moveSpeed = 6f, dashBoostSpeed;
    public Rigidbody2D rb;
    Vector3 movement;

    Vector3 DiagonalMove;
    // public bool canSprint;

    public bool isDashButtonDown, isReleasedDash;
    public bool hasFinishedDashing;
    public float dashPower = 2f;    //min dash power is 2 and max is 6
    public float maxDashPower = 6f; //max dash power

    [SerializeField] private float dashBoostSpeedDuration, dashBoostSpeedDurationSubtract;

    public bool canDash, canAddSpeed;

    private void Start()
    {
        hermesBootsScript = FindObjectOfType<HermesBoots>();
        dashStaminaScript = FindObjectOfType<DashStamina>();
        rb = GetComponent<Rigidbody2D>();
        canDash = true;

        //canSprint = true;

    }
    // Update is called once per frame
    void Update()
    {
        //Handle inputs
        GetInput();

        //Player's speed after picking up the hermes boots
        HermesBootsPicking();
        StartDashBoostCooldown();
    }
    void FixedUpdate()
    {
        //Handle movements stuff 
        rb.velocity = movement * moveSpeed;
        Dash();
        //Sprint();
        
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
            isDashButtonDown = true;
            isReleasedDash = false;
            dashPower = dashPower += Time.deltaTime;
            hasFinishedDashing = false;

        }

        //When the SPACE key is released, set isDashButtonDown to false
        if (Input.GetKeyUp(KeyCode.Space))
        {

            isDashButtonDown = false;
            isReleasedDash = true;
            

            //subtracting dash stamina by 20
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
        if (!isDashButtonDown && isReleasedDash && canDash)
        {
            rb.MovePosition(transform.position + movement * dashPower);
            
            BoostSpeedAfterDashing();
           
        }
    }
    
    void HermesBootsPicking()
    {
        if (hermesBootsScript.HermesBootsPickedUp)
        {
            moveSpeed = hermesBootsScript.currentSpeed;
            //canSprint = false;
        }
    }
    void BoostSpeedAfterDashing()
    {
        //When the player is not holding down 
        //and released the dash button
        if (isReleasedDash)
        {
            //Adding speed to the player
            
            hasFinishedDashing = true;
            canAddSpeed = true;
            
            //When the player released the dash button, it counts as the player has finished the dashing input
            if (hasFinishedDashing && canAddSpeed)  
            {
                
                moveSpeed += dashBoostSpeed;
                canAddSpeed = false;
                isReleasedDash = false;
            }
        }
    }
    void StartDashBoostCooldown()
    {
        if (!canAddSpeed && hasFinishedDashing)
        {
            dashBoostSpeedDuration -= Time.deltaTime;
            
        }
        if (dashBoostSpeedDuration <= 0)
        {
            canAddSpeed = true;
            hasFinishedDashing = false;
            dashBoostSpeedDuration = 2.5f;
            moveSpeed = 6f;
        }

    }
}

    
