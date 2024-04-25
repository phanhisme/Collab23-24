using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornArmor : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] PlayerPointer playerPointer;
    [SerializeField] EnemyWeaponHolder enemyWeaponHolder;
    private float itemUsage = 2;
    private float nextUsage = 2;
    private float damageReflectMultiplier = 5;
    public bool isThornArmorActive;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        playerPointer = FindObjectOfType<PlayerPointer>();
        enemyWeaponHolder = FindObjectOfType<EnemyWeaponHolder>();
    }

    void ReflectDamage()
    {
        if(isThornArmorActive && itemUsage > 0) 
        {
            enemyHealth.currentHealth = enemyHealth.currentHealth - enemyWeaponHolder.enemyDamage * damageReflectMultiplier;
            itemUsage--;
        }
    }

    void checkForTA()
    {
        if(playerPointer.thornArmorActive == true)
        {
            isThornArmorActive = true;
        }
        if(itemUsage == 0)
        {
            itemUsage = nextUsage;
            isThornArmorActive = false;
        }
    }
}
