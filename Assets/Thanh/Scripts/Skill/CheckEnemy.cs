using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    public float needleDamage = 5;
    EnemyHealth enemyHealth;
    private void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHealth.currentHealth -= needleDamage;
            //Destroy(collision);
        }
    }
}
