using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectDeath : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private float playerCurrentHealth;
    private GameObject rejectDeathGO;
    
    [SerializeField] private bool isRejectDeathEquipped = false;
    [SerializeField] private bool canTriggerRejectDeath = false;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        rejectDeathGO = GameObject.Find("RejectDeath");
        _playerHealth.currentHealth = playerCurrentHealth;
    }

    private void Update()
    {
        //Find the reject death game object in the player as a child
        foreach (Transform eachChild in transform)  
        {
            //When the player found the reject death object
            if (eachChild.name == "RejectDeath")
            {
                isRejectDeathEquipped = true;
                canTriggerRejectDeath = true;
                Debug.Log(eachChild.name);
            }
        }
        TriggerRejectDeath();
    }

    void TriggerRejectDeath()
    {
        
    }
    
}
