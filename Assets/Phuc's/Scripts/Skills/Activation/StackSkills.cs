using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSkills : MonoBehaviour
{
    [Header("Invisibility Related")]
    PlayerMovement pmScript;
    Invisibility invisScript;

    [SerializeField] private int invisMaxStack = 2;
    [SerializeField] private float invisStackCooldown = 8;
    private bool ifThereIsStack, IsUsingInvis, hasInvisCountSubtracted;
    public bool InvisButtonPress;
    [SerializeField] private int invisStackSubtract = 1;

    // Start is called before the first frame update
    void Start()
    {
        pmScript = FindObjectOfType<PlayerMovement>();
        invisScript = FindObjectOfType<Invisibility>();
        //---- INVISIBILITY RELATED ----
        
        ifThereIsStack = true;
        hasInvisCountSubtracted = false;
    }

    // Update is called once per frame
    void Update()
    {
        SubtractInvisCount();
    }


    //---- INVISIBILITY ---- \\
    void SubtractInvisCount()
    {
        //If the invis button is pressed, this boolean will check if the count is
        //subtracted or not will turn to true
        if(InvisButtonPress)
        {
            hasInvisCountSubtracted = true;
            if(hasInvisCountSubtracted)
            {
                //if it is subtracted, decrease the max stack and set the boolean back to false immidiately
                //to prevent the number goes below 0
                invisMaxStack -= invisStackSubtract;
                hasInvisCountSubtracted = false;
            }
            if(!hasInvisCountSubtracted)
            {
                InvisButtonPress = false;   //if the player stack count is not subtracted, the player can't press invis
            }
        }
        //if the invis stack reaches 0, starts the 8s cooldown and the player 
        //can't go invis until the cooldown is finished
        if (invisMaxStack <= 0)
        {
            InvisStackCooldown();
            if(!ifThereIsStack)
            {
                invisScript.canButtonPressed = false;   //button boolean in the invis script
            }
        }
    }
    void InvisStackCooldown()
    {
        //check if there is stack or not
        //In this case, invisMaxStack is 0 so this boolean will turn to false
        ifThereIsStack = false;

        //If there are no stacks remaining, starts the cooldown
        if (!ifThereIsStack)
        {
            invisStackCooldown -= Time.deltaTime;
        }
        //If the cooldown is finished, reset all the numbers and turn on the stacks boolean
        if(invisStackCooldown <= 0)
        {
            invisMaxStack = 2;
            ifThereIsStack = true;
            invisStackCooldown = 8;
            pmScript.canDash = true;
        }
    }
}
