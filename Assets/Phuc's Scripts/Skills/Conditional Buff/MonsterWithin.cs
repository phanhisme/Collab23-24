using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

/*This conditional buff happens when the player reaches 1 hp 
and will increase atk damage by 25%*/
public class MonsterWithin : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerWeaponHolder _playerWeaponHolder; 
    [SerializeField] bool hasBuffed = false;    //in this situation, when the player hits 1hp
    private bool isMonsterWithinActivated = false;
    private GameObject playerPos;
    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _playerWeaponHolder = FindObjectOfType<PlayerWeaponHolder>();
        playerPos = GameObject.FindWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(playerPos.transform);

            isMonsterWithinActivated = true;
        }
    }
    private void Update()
    {
        if (_playerHealth.currentHealth <= 1 && isMonsterWithinActivated)
        {
            //I don't really know math lul but this increase dmg by 25% when the player reaches 1hp
            _playerWeaponHolder.playerDamage += _playerWeaponHolder.playerDamage * 0.25f;
            hasBuffed = true;
            if(hasBuffed)
            return;
        }
    }
    

}
