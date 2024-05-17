using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<CreateQuest> allQuest = new List<CreateQuest>();
    public List<CreateQuest> addedQuest = new List<CreateQuest>();

    public void RandomQuestData()
    {
        int i = Random.Range(0, allQuest.Count);

        CreateQuest randQuest = allQuest[i];
        addedQuest.Add(randQuest); 
    }

    public void OnGoingQuest(QuestLogic chosenQuest)
    {
        if (chosenQuest != null)
        {
            chosenQuest = this.gameObject.GetComponent<QuestLogic>();
            chosenQuest.currentStatus = QuestLogic.Status.ONGOING;
        }
        else
        {
            //find existing quest in the 
            chosenQuest.currentStatus = QuestLogic.Status.ONGOING;
        } 
    }

    //public
}
 