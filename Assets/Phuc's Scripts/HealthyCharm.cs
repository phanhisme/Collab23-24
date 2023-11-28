using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyCharm : MonoBehaviour
{
    PlayerMovement pmScript;
    DashStamina dashStaminaScript;

    private bool isPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        pmScript = FindObjectOfType<PlayerMovement>();
        dashStaminaScript = FindObjectOfType<DashStamina>();
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the player picked the charm, set the boolean to true
        //and the stamina cost turns to 10 instead of 20
        if (collision.gameObject.CompareTag("Player"))
        {
            isPickedUp = true;
            if (isPickedUp)
            {
                dashStaminaScript.StaminaSubtraction = 15;
                Destroy(gameObject);
            }
        }
    }





}
