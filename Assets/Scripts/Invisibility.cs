using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    private SpriteRenderer srCharacter;
    private Color charColor;
    public float activateDuration;
    public bool isActivated = false;
    private float colorDuration;


    EnemyPatrol enemyPatrolScript;
    // Start is called before the first frame update
    void Start()
    {
        srCharacter = GetComponent<SpriteRenderer>();
        activateDuration = 5;
        charColor = srCharacter.color;
        enemyPatrolScript = FindObjectOfType<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {

        //The duration decreases over time
        activateDuration -= Time.deltaTime;


        //When presses F, set the isActivated bool to true
        //Reset the duration and set the color of the player to green
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SwitchColor());
            isActivated = true;
            activateDuration = 5;
            charColor = srCharacter.color;

        }


        //If the duration reaches 0, the player returns to red color
        //And the enemy can detect the player again
        if (activateDuration <= 0)
        {
            srCharacter.color = new Color(1f, 0f, 0f);      //red color
            enemyPatrolScript.detectionDistance = 6f;
        }
    }

    //Switch the color of the player function
    //Deactivate the detection circle of the enemy
    IEnumerator SwitchColor()
    {
        srCharacter.color = new Color(0f, 1f, 0f);
        yield return new WaitForSeconds(colorDuration);
        srCharacter.color = charColor;
        enemyPatrolScript.detectionDistance = 0f;
    }
}


