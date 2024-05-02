using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifesteal : MonoBehaviour
{
    private bool isLifeStealActive;
    public float healChance = 0.2f;

    [SerializeField] private GameObject playerPos;

    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyHealth _enemyHealth;

    public float randomChance;
    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyHealth = FindObjectOfType<EnemyHealth>();

        playerPos = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(playerPos.transform);
            
            isLifeStealActive = true;
        }
    }
    public void LifestealAfterHit()
    {
        if (isLifeStealActive)
        {
            randomChance = Random.Range(0f, 1f);
            

        }
        

    }
}

