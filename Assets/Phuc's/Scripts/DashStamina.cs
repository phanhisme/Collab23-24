using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashStamina : MonoBehaviour
{
    PlayerMovement pmScript;
    [SerializeField] private int maxDashStamina = 80;
    [SerializeField] public int StaminaSubtraction = 20;
    public bool ifOutOfStamina, startSubtractingStamina;
    [SerializeField] private float DashStaminaCooldown = 3f;
    // Start is called before the first frame update
    void Start()
    {
        pmScript = FindObjectOfType<PlayerMovement>();
        ifOutOfStamina = false;
        startSubtractingStamina = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        DashStaminaSubtraction();
    }

    void DashStaminaSubtraction()
    {
        //If the player released the dashing key, the stamina starts to subtract
        if(startSubtractingStamina)
        {
            maxDashStamina -= StaminaSubtraction;
            startSubtractingStamina = false;
            if (maxDashStamina <= -20)
            {
                ifOutOfStamina = true;
                pmScript.canDash = false;
            }
        }
        DashStaminaCooldownCounter();
    }
    void DashStaminaCooldownCounter()
    {
        //If the player has no stamina left, the cooldown starts
        if(ifOutOfStamina)
        {
            DashStaminaCooldown -= Time.deltaTime;
            maxDashStamina = 0;
        }

        //If the cooldown is finished, set the stamina back to 80
        if (DashStaminaCooldown <= 0)
        {
            ifOutOfStamina = false;
            maxDashStamina = 80;
            DashStaminaCooldown = 3;
            pmScript.canDash = true;
        }
    }
}
