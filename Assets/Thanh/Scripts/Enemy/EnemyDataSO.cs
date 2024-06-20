using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData"/*, menuName = "Data/EnemyData"*/)]
public class EnemyDataSO : ScriptableObject
{
    //public int ID;
    //public float health;
    //public float speed;
    //public float attackRange;
    //public float attackSpeed;
    //public float baseDamage;
    //public float skillDamage;
    public float baseGoldDrop;
    public float finalGoldDrop;
    public float currencyMultiplier;
    public RewardType rewardType;
}

