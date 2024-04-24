using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectDeath : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private EnemyPatrol _enemyPatrol;
    [SerializeField] private GameObject playerGO;
    
    public bool isRejectDeathEquipped = false;

    [SerializeField] private float invincibleTimer;
    [SerializeField] private bool isInvincible;
    
    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyPatrol = FindObjectOfType<EnemyPatrol>();
        playerGO = GameObject.Find("Player");
    }
    private void Update()
    {
        if (transform.parent == playerGO.transform)
        {
            isRejectDeathEquipped = true;
            StartCoroutine(TriggerInvincible());
        }
    }
    IEnumerator TriggerInvincible()
    {
        if (isRejectDeathEquipped && _playerHealth.currentHealth == 0)
        {
            isInvincible = true;
            if (isInvincible)
            {
                _playerHealth.isHurt = true;
            }
            yield return new WaitForSeconds(invincibleTimer);
            isInvincible = false;
            Destroy(gameObject);
            isRejectDeathEquipped = false;
            _playerHealth.currentHealth = 1;
        }
        
    }
}
