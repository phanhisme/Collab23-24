using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifesteal : MonoBehaviour
{
    public bool isLifeStealActive;
    public float healChance = 0.2f;

    [SerializeField] private GameObject playerPos;

    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private PlayerWeaponHolder _playerWeaponHolder;

    

    public float randomChance;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyHealth = FindObjectOfType<EnemyHealth>();

        playerPos = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(playerPos.transform);
            isLifeStealActive = true;
           
        }
        else
        {
            isLifeStealActive = false;
        }
    }
    public void LifestealAfterHit()
    { 
        //Returns the value of 0 to 1
        randomChance = Random.value;
        if (randomChance < healChance)
        {            
            _playerHealth.currentHealth += 1;
        }
    }
}





