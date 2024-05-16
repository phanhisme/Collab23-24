using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData 
{
    public float baseGoldDrop;
    public float finalGoldDrop;
    public float currencyMultiplier;
    public RewardType rewardType;
}

public enum RewardType
{
    GOLD,
}
