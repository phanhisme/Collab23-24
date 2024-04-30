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
    private float damageReflectMultiplier = 5;
    public bool isThornArmorActive;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        playerPointer = FindObjectOfType<PlayerPointer>();
        enemyWeaponHolder = FindObjectOfType<EnemyWeaponHolder>();
    }
    private void Update()
    {
        checkForTA();
        ReflectDamage();
    }
    void ReflectDamage()
    {
        if(isThornArmorActive == true && itemUsage > 0 && playerHealth.isHurt == true) 
        {
            enemyHealth.currentHealth = enemyHealth.currentHealth - enemyWeaponHolder.enemyDamage * damageReflectMultiplier;
            itemUsage--;
        }
        if (itemUsage == 0)
        {
            isThornArmorActive = false;
            itemUsage = 2;
            playerPointer.DeActivateTA();

        }
    }

    void checkForTA()
    {
        if(playerPointer.thornArmorActive == true)
        {
            isThornArmorActive = true;
        }
    }
}
