using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frostbite : MonoBehaviour
{
    public float frostChance = 0.35f;
    public float randomChance;
    public bool isEnemyFrosted;
    public float slowMultiplier = 0.5f;
    PlayerPointer playerPointer;
    EnemyHealth enemyHealth;
    EnemyPatrol enemyPatrol;
}
