using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectDeath : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private EnemyPatrol _enemyPatrol;
    
    [SerializeField] private float playerCurrentHealth;
    [SerializeField] private GameObject rejectDeathGO;
    
    public bool isRejectDeathEquipped = false;

    [SerializeField] private float invincibleTimer = 2.0f;
    [SerializeField] private bool isInvincible;
    
    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyPatrol = FindObjectOfType<EnemyPatrol>();
        rejectDeathGO = GameObject.Find("RejectDeath");
        playerCurrentHealth = _playerHealth.currentHealth;
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
                StartCoroutine(TriggerInvincible());
                Debug.Log(playerCurrentHealth);
            }
        }
       
    }
    IEnumerator TriggerInvincible()
    {
        if (isRejectDeathEquipped && playerCurrentHealth == 0)
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibleTimer);
            isInvincible = false;
            Destroy(rejectDeathGO);
            isRejectDeathEquipped = false;
            playerCurrentHealth = 1;
        }

        while (isInvincible)
        {
            //while the player is invincible, the enemy cannot detect the player
            _enemyPatrol.hasDetectPlayer = false;
        }
    }
}
