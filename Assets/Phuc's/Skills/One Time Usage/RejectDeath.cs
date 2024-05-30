using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectDeath : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private EnemyPatrol _enemyPatrol;
    
    public bool isRejectDeathEquipped = false;

    [SerializeField] private float invincibleTimer;
    [SerializeField] private bool isInvincible;

    private GameObject playerPos;
    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyPatrol = FindObjectOfType<EnemyPatrol>();
        playerPos = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (transform.parent == playerPos.transform)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(playerPos.transform);
        }
    }
}
