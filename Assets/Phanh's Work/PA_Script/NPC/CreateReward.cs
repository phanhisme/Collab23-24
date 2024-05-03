using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest System/Create Rewards")]
public class CreateReward : ScriptableObject
{
    public Sprite rewardIcon;
    public int rewardAmount;
    public float questTime; //for quest which counts time like online for zz minutes

    
}
