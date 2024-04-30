using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    //public GameObject questPrefab;
    //public Transform contentPanel;

    //// Public method to add a quest
    //public void AddQuest(string questName)
    //{
    //    GameObject questItem = Instantiate(questPrefab);
    //    questItem.transform.SetParent(contentPanel);
    //    questItem.GetComponentInChildren<Text>().text = questName;
    //}
    [System.Serializable]
    public class Quest
    {
        public string questName;
        public string questDescription;
        // Add other quest properties here
    }
    
        public List<Quest> quests = new List<Quest>();

        public void AddQuest()
        {
            Quest newQuest = new Quest();
            newQuest.questName = "New Quest";
            newQuest.questDescription = "New Description";
            quests.Add(newQuest);
        }
    
}
