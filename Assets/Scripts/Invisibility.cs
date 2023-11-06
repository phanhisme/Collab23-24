using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    private SpriteRenderer character;
    private Color charColor;
    public float activateDuration;
    public bool isActivated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<SpriteRenderer>();
        
        activateDuration = 0;
        charColor = character.color;
    }

    // Update is called once per frame
    void Update()
    {
        activateDuration += Time.deltaTime;
        //When presses F, set the isActivated bool to true
        //Reset the duration and set the transparency of the player to a blurry state
        if(Input.GetKeyDown(KeyCode.F))
        {
            isActivated = true;
            activateDuration = 0;
            charColor.a = 0.2f;
            charColor = character.color;
        }
        EndofDuration();
    }
    //When the duration ended, set the isActivated bool to false
    //Set the transparency to opaque
    void EndofDuration()
    {
        if (isActivated && activateDuration >= 5)
        {
            isActivated = false;
            charColor.a = 1;
            charColor = character.color;
        }
    }
    



}

