using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectDeath : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private float playerCurrentHealth;
    private GameObject rejectDeathGO;
    
    public bool isRejectDeathEquipped = false;

    [SerializeField] private float invincibleTimer = 2.0f;
    [SerializeField] private bool isInvincible;

    //private int m_IndexNum;
    
    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        rejectDeathGO = GameObject.Find("RejectDeath");
        playerCurrentHealth = _playerHealth.currentHealth;
        Debug.Log(playerCurrentHealth);

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
                //Debug.Log(invincibleTimer);
            }
        }       
    }
    IEnumerator TriggerInvincible()
    {
        if (isRejectDeathEquipped && playerCurrentHealth <= 0)
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibleTimer);
            Destroy(rejectDeathGO);
        }
    }
}
