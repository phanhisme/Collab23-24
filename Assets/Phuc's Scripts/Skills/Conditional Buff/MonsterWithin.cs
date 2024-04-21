using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

/*This conditional buff happens when the player reaches 1 hp 
and will increase atk damage by 20%*/
public class MonsterWithin : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private PlayerPointer _playerPointer;
    private bool hasBuffed = false;
    private void Start()
    {
        _playerHealth = GetComponent<Health>();
        _playerPointer = GetComponent<PlayerPointer>();
    }


    private void Update()
    {
        if (_playerHealth.currentHealth <= 1  && !hasBuffed)
        {
            _playerPointer.playerDamage = _playerPointer.playerDamage * .25f;
            Debug.Log(_playerPointer.playerDamage);
        }
    }
}
