using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class QuestTrack
{
    [SerializeField] public CreateQuest createQuest;
    [SerializeField] public int progressionNumber;
    [SerializeField] public CreateQuest.QuestItem questItem;

    public QuestTrack(CreateQuest quest, CreateQuest.QuestItem item, int progression)
    {
        createQuest = quest;
        questItem = item;
        progressionNumber = progression;
    }

    public CreateQuest GetQuest() { return createQuest; }
    public CreateQuest.QuestItem GetItems() { return createQuest.questItem; }
    public int GetProgressionNumber() { return progressionNumber; }
}