using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{

    private bool isInInvis = false, canInvis = true, isInvisButtonPressed = false;


    //Invisibility duration = 4
    //Invisibility CD = 6
    public float invisDuration, invisCooldown;


    EnemyPatrol enemyPatrolScript;
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isInvisButtonPressed = true;
        }
    }
    private void FixedUpdate()
    {
        InvisibilitySkill();
    }

    void InvisibilitySkill()
    {
        GetInvisInput();
        PlayerInInvis();
        OutofInvisDuration();
    }
    void PlayerInInvis()
    {
        //If the bool is true, the enemy cannot detect 
        if (isInInvis)
        {             
            invisDuration -= 0.5f;    //decrease the duration   
        }
    }
    void GetInvisInput()
    {
        if (isInvisButtonPressed && canInvis)
        {
            //If the invis button "F" is pressed, and the player can go invis
            //Set the is in invisibility bool to true
            isInInvis = true;
            
        }
    }
    void OutofInvisDuration()
    {
        if (invisDuration <= 0)  //if the duration gone out, the invis starts CD
        {
            isInInvis = false;
            invisCooldown = 6f;
            invisCooldown = invisCooldown - 0.5f;
            
        }
    }

}

