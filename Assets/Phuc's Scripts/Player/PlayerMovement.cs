using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    HermesBoots hermesBootsScript;
    DashStamina dashStaminaScript;

    //For reference with the prefabs
    public Transform childPrefab;

    public float moveSpeed = 6f, dashBoostSpeed;
    public Rigidbody2D rb;
    Vector3 movement;

    Vector3 DiagonalMove;
    // public bool canSprint;
    public bool isDashButtonDown, isReleasedDash;
    public bool hasFinishedDashing, checkOnce;
    public float dashPower = 6f;    //min dash power is 6 and max is 10
    public float maxDashPower = 10f; //max dash power
    
    [SerializeField] private float dashBoostSpeedDuration, dashBoostSpeedDurationSubtract;
    [Space]
    public float _currentBoostSpeedDuration, _currentMoveSpeed;
    public bool canDash, canAddSpeed;

    private void Start()
    {
        hermesBootsScript = FindObjectOfType<HermesBoots>();
        dashStaminaScript = FindObjectOfType<DashStamina>();
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
        canAddSpeed = true;

        //canSprint = true;

    }
    // Update is called once per frame
    void Update()
    {
        //Handle inputs
        GetInput();

        //Player's speed after picking up the hermes boots
        //HermesBootsPicking();
        StartDashBoostCooldown();
        
    }
    void FixedUpdate()
    {
        //Handle movements stuff 
        rb.velocity = movement * _currentMoveSpeed;
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
            hasFinishedDashing = false;
            dashPower = dashPower += Time.deltaTime;
            
        }

        //When the SPACE key is released, set isDashButtonDown to false
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isDashButtonDown = false;
            isReleasedDash = true;
            hasFinishedDashing = true;
            //subtracting dash stamina by 20
            dashStaminaScript.startSubtractingStamina = true;

            _currentBoostSpeedDuration = dashBoostSpeedDuration;

        }
        

        /* If the current dash power is bigger or equal to the max dash power
        then set the isDashButtonDown boolean to false and set the power back to 6 */
        if (dashPower >= maxDashPower)
        {
            dashPower = 6f;
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
            isReleasedDash = false;
        }
    }
    
    /*void HermesBootsPicking()
    {
        if (hermesBootsScript.HermesBootsPickedUp)
        {
            _currentMoveSpeed = hermesBootsScript.currentSpeed;
            //canSprint = false;
        }
    }*/
    void BoostSpeedAfterDashing()
    {
        //When the player is not holding down 
        //and released the dash button
        if (isReleasedDash)
        {
            //Adding speed to the player
            //When the player released the dash button, it counts as the player has finished the dashing input
            if (canAddSpeed)  
            {
                _currentMoveSpeed = moveSpeed + dashBoostSpeed;

                //Player's speed cap
                if (moveSpeed > 20)
                {
                    canAddSpeed = false;
                }
            }
        }
    }
    
    void StartDashBoostCooldown()
    {
        if (_currentBoostSpeedDuration > 0f)
        {
            _currentBoostSpeedDuration -= Time.deltaTime;
            checkOnce = false;

        }

        else if (_currentBoostSpeedDuration <= 0)
        {
            _currentBoostSpeedDuration = 0f;
            canAddSpeed = true;
            hasFinishedDashing = false;
            dashBoostSpeedDuration = 2.5f;
            if(!checkOnce)
            {
                CheckForSpeed();
            }
        }
    }
    void CheckForSpeed()
    {
        _currentMoveSpeed = moveSpeed;
        checkOnce = true;
    }
}

    
