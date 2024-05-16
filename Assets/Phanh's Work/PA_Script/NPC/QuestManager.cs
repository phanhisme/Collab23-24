using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<CreateQuest> allQuest = new List<CreateQuest>();
    public List<CreateQuest> addedQuest = new List<CreateQuest>();

    public void RandomQuestData(CreateQuest randQuest)
    {
        int i = Random.Range(0, allQuest.Count);

        randQuest = allQuest[i];
        addedQuest.Add(randQuest);

        switch (i)
        {
            case 0: //quest 01
                
                
                break;

            case 1:
                
                break;

            case 2:
                
                break;

            case 3:
                
                break;
        }

        
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
