using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyHabit : MonoBehaviour
{

    [SerializeField] private bool isEquipped = true;
    PlayerHealth healthScript;

    // Start is called before the first frame update

    private void Awake()
    {
        healthScript = FindObjectOfType<PlayerHealth>();
    }
    void Start()
    {
        //If it is equipped, increase max health of the player by 1
        if(isEquipped)
        {
            healthScript.maxHealth = healthScript.maxHealth + 1;
        }
    }

    
}
