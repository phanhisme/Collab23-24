using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float enemyCurrentHealth;
    private Rigidbody rb;
    [SerializeField] EnemyHealthbar healthBar;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        healthBar = GetComponentInChildren<EnemyHealthbar>();
    }
    void Start()
    {
        healthBar.UpdateHealthBar(enemyCurrentHealth, enemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
        healthBar.UpdateHealthBar(enemyCurrentHealth, enemyHealth);
        if(enemyCurrentHealth < 0 )
        {
            Die();
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
