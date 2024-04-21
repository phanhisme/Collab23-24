using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This conditional buff happens when the player reaches 1 hp 
and will increase atk damage by 20%*/
public class MonsterWithin : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private PlayerPointer _playerPointer; 
    private bool HPConditionMet;    //in this situation, when the player hits 1hp
    private void Start()
    {
        _playerHealth = GetComponent<Health>();
        _playerPointer = GetComponent<PlayerPointer>();
    }
}
