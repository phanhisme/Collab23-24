using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroCheck : MonoBehaviour
{

    public GameObject _playerTar { get; set; }

    [SerializeField] private Enemy _enemyScript;

    
    
    private void Start()
    {
        _playerTar = GameObject.FindGameObjectWithTag("Player");
        _enemyScript = GetComponentInParent<Enemy>();
    }
    //TODO: When the player enter aggro area
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _playerTar)
        {
            _enemyScript.SetAggroStatus(true); 
        }
    }
    //TODO: When the player exit aggro area

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == _playerTar)
        {
            _enemyScript.SetAggroStatus(false); 
        }
    }
}
