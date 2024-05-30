using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<CreateQuest> addedQuest = new List<CreateQuest>();

    public void RandomQuestData()
    {
       
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
 