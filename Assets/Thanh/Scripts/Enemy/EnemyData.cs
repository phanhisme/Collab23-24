using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData 
{
    //public int ID;
    //public float health;
    //public float speed;
    //public float attackRange;
    //public float attackSpeed;
    //public float attackdamage;
    //public float skillDamage;
    public float baseGoldDrop;
    public float finalGoldDrop;
    public float currencyMultiplier;
    public RewardType rewardType;
}

public enum RewardType
{
    GOLD,
}
