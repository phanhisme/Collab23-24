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
    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerWeaponHolder = GetComponent<PlayerWeaponHolder>();
    }
    private void Update()
    {
        if (_playerHealth.currentHealth <= 1 && !hasBuffed)
        {
            //I don't really know math lul but this increase dmg by 25% when the player reaches 1hp
            _playerWeaponHolder.playerDamage += _playerWeaponHolder.playerDamage * 0.25f;
            hasBuffed = true;
            if(hasBuffed)
            return;
        }
    }
}
