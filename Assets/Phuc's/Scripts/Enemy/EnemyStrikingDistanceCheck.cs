using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrikingDistanceCheck : MonoBehaviour
{
    public GameObject _playerTar { get; set; }

    private Enemy _enemyScript;

    
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
            _enemyScript.SetStrikingDistanceBool(true); 
        }
    }
    //TODO: When the player exit aggro area

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == _playerTar)
        {
            _enemyScript.SetStrikingDistanceBool(false); 
        }
    }
}
