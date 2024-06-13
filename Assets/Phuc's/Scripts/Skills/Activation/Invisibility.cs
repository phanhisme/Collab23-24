using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    private SpriteRenderer srCharacter;
    private Color charColor;
    public float activateDuration;
    public bool isActivated = false, canButtonPressed, isPressed = false;
    private float colorDuration;

    StackSkills stackskillsScript;
    //EnemyPatrol enemyPatrolScript;
    WeaponBase weaponBase;
    // Start is called before the first frame update
    void Start()
    {
        canButtonPressed = true;
        srCharacter = GetComponent<SpriteRenderer>();
        activateDuration = 5;
        charColor = srCharacter.color;
        //enemyPatrolScript = FindObjectOfType<EnemyPatrol>();
        stackskillsScript = FindObjectOfType<StackSkills>();
        weaponBase = FindObjectOfType<WeaponBase>();
    }

    // Update is called once per frame
    void Update()
    {
        //When presses F, set the isActivated bool to true
        //Reset the duration and set the color of the player to green
        if (Input.GetKeyDown(KeyCode.F) && canButtonPressed)
        {
            
            stackskillsScript.InvisButtonPress = true;
            StartCoroutine(SwitchColor());
            canButtonPressed = false;
            isActivated = true;
            activateDuration = 5;
            charColor = srCharacter.color;
            
        }
        if(isActivated)
        {
            canButtonPressed = false;
            //The duration decreases over time
            activateDuration -= Time.deltaTime;
        }
        else if(!isActivated)
        {
            canButtonPressed = true;
        }
        ResetInvis();
    }

    //Switch the color of the player function
    //Deactivate the detection circle of the enemy
    IEnumerator SwitchColor()
    {
        srCharacter.color = new Color(0f, 1f, 0f);
        yield return new WaitForSeconds(colorDuration);
        srCharacter.color = charColor;
       // enemyPatrolScript.detectionDistance = 0f;
        
    }

    public void ResetInvis()
    {
        //If the duration reaches 0, the player returns to white color
        //And the enemy can detect the player again
        if (activateDuration <= 0)
        {
            srCharacter.color = new Color(255f, 255f, 255f);      //white color
           // enemyPatrolScript.detectionDistance = 6f;
            canButtonPressed = true;
            isActivated = false;
            stackskillsScript.InvisButtonPress = false;
            weaponBase.canInstaKill = false;
        }
    }
}


