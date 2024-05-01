using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest System/Create Quest")]
public class CreateQuest : ScriptableObject
{
    public string questName;

    public Sprite rewardIcon;
    public int rewardAmount;

    public string amountNeeded;
    public float questTime; //for quest which counts time like online for zz minutes

    public QuestItem questItem;

    public enum QuestItem
    {
        Currency, PickUps, Villagers, EnemyDrops
    }
}
