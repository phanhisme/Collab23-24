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

    private int m_IndexNum;
    
    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        rejectDeathGO = GameObject.Find("RejectDeath");
        playerCurrentHealth = _playerHealth.currentHealth;
        Debug.Log(playerCurrentHealth);
        
        //Set object to an index
        transform.SetSiblingIndex(m_IndexNum);
        Debug.Log(transform.GetSiblingIndex());
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
                rejectDeathGO = this.transform.GetChild(0).gameObject;
                StartCoroutine(TriggerInvincible());
                Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            }
        }
    }
    IEnumerator TriggerInvincible()
    {
        if (isRejectDeathEquipped && playerCurrentHealth == 0)
        {
            isInvincible = true;
            
            playerCurrentHealth = 1;
            yield return new WaitForSeconds(invincibleTimer);
        }
    }
    
    
}
