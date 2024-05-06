using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifesteal : MonoBehaviour
{
    [SerializeField] private bool isLifeStealActive;
    public float healChance = 0.2f;

    [SerializeField] private GameObject playerPos;

    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private PlayerWeaponHolder _playerWeaponHolder;

    [SerializeField] private bool canHeal = false;

    public float randomChance;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _enemyHealth = FindObjectOfType<EnemyHealth>();

        playerPos = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (_enemyHealth.isHit && isLifeStealActive)
        {
            StartCoroutine(LifestealAfterHit());
            Debug.Log(randomChance);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(playerPos.transform);
            isLifeStealActive = true;
            canHeal = true;
        }
        else
        {
            isLifeStealActive = false;
        }
    }
    public IEnumerator LifestealAfterHit()
    {
        
        randomChance = Random.Range(0f, 1f);
        if (_playerWeaponHolder.GetComponent<PlayerWeaponHolder>().isAttacking && randomChance < healChance && canHeal)
        {            
            _playerHealth.currentHealth += 1;
            canHeal = false;
        }
        yield return new WaitForSeconds(0f);
    }
}





