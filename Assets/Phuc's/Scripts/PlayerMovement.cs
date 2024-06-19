using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    HermesBoots hermesBootsScript;
    DashStamina dashStaminaScript;

    private Animator anim;
    //For reference with the prefabs
    
    public float moveSpeed = 6f, dashBoostSpeed;
    public Rigidbody2D rb;
    Vector3 movement;

    Vector3 DiagonalMove;
    // public bool canSprint;
   
    public float dashPower = 6f;    //min dash power is 6 and max is 10
 
    
    [SerializeField] private float dashBoostSpeedDuration, dashBoostSpeedDurationSubtract;
    [Space]
    public float _currentBoostSpeedDuration, _currentMoveSpeed;
    public bool canDash, canAddSpeed, hasDashButtonPressed, isFacingRight;

    private SpriteRenderer sr;
    private void Start()
    {
        hermesBootsScript = FindObjectOfType<HermesBoots>();
        dashStaminaScript = FindObjectOfType<DashStamina>();
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
        canAddSpeed = true;
        sr = GetComponent<SpriteRenderer>();
        //canSprint = true;
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        DashingInput();
        Debug.Log(movement);
    }
    void FixedUpdate()
    {
        GetInput();
         
        rb.velocity = movement * _currentMoveSpeed;
    }


    //HANDLING FUNCTIONS
    void GetInput()
    {
        //Player movement inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        var playerVelocity = rb.velocity;
        
        //TODO: Flipping the player sprite
        sr.transform.localScale = new Vector2(isFacingRight ? Mathf.Abs(sr.transform.localScale.x) : -Mathf.Abs(sr.transform.localScale.x), sr.transform.localScale.y);
        if (playerVelocity.x > 0)
        {
            isFacingRight = true;
        }
        else if (playerVelocity.x < 0)
        {
            isFacingRight = false;
        }
        
        //Prevent the player move faster when going diagonally
        DiagonalMove = new Vector3(movement.x, movement.y).normalized;

        if (rb.velocity.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    
    #region Dashing Related
    void DashingInput()
    {
        //When the Space key is held down and the current dash power is smaller than the dash power
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            hasDashButtonPressed = true;
            dashStaminaScript.startSubtractingStamina = true;
            rb.MovePosition(transform.position + movement * dashPower);
            BoostSpeedAfterDashing();
            StartDashBoostCooldown();
        }
        else if (hasDashButtonPressed)
        {
            anim.SetTrigger("isDashing");
            hasDashButtonPressed = false;
        }
    }
    
    void BoostSpeedAfterDashing()
    {
        if (canAddSpeed)
        {
            _currentMoveSpeed = moveSpeed + dashBoostSpeed;
        }
        if (moveSpeed > 20)
        {
            canAddSpeed = false;
        }
    }
    
    void StartDashBoostCooldown()
    {
        if (_currentMoveSpeed > moveSpeed)
        {
            _currentBoostSpeedDuration -= dashBoostSpeedDurationSubtract;
            Debug.Log(moveSpeed);
        }
        else if (_currentBoostSpeedDuration <= 0)
        {
            _currentBoostSpeedDuration = 0f;
            canAddSpeed = true;
            dashBoostSpeedDuration = 1.5f;
            _currentMoveSpeed = moveSpeed;
        }
    }
    
    #endregion
}

    
