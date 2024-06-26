using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frostbite : MonoBehaviour
{
    public float frostChance = 35;
    public float randomChance;
    public bool isSlowed;
    public float slowMultiplier = 0.5f;
    public float slowDuration = 5;
    PlayerPointer playerPointer;
    EnemyHealth enemyHealth;
    Enemy enemy;

    private void Start()
    {
        playerPointer = FindObjectOfType<PlayerPointer>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        enemy = FindObjectOfType<Enemy>();
    }
    public void checkForFrostChance()
    {
        randomChance = Random.Range(0, 101);
        //Debug.Log(randomChance);
        if(randomChance <= frostChance && isSlowed == false && enemyHealth.isHit == true && playerPointer.fbActive == true)
        {
            //enemy.speed = enemyPatrol.speed * slowMultiplier;
            StartCoroutine(SlowDuration(slowDuration));
            //Debug.Log("Slowed");
        }
        else if(playerPointer.fbActive == false || randomChance > frostChance || isSlowed == true && enemyHealth.isHit == true) 
        {
            //Debug.Log("NotSlowed");
            return;
        }
    }

    public IEnumerator SlowDuration(float slowDuration)
    {
        isSlowed = true;
        yield return new WaitForSeconds(slowDuration);
        isSlowed = false;
    }
}
