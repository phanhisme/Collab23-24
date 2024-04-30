using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData"/*, menuName = "Data/EnemyData"*/)]
public class EnemyDataSO : ScriptableObject
{
    public float baseGoldDrop;
    public float finalGoldDrop;
    public float currencyMultiplier;
    public RewardType rewardType;
}

