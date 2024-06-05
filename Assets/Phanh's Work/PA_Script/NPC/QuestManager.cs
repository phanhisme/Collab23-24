using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<CreateQuest> addedQuest = new List<CreateQuest>();

    public GameObject questPrefab;
    public Transform contenTransform;

    int previousQuestQuantity = 0;

    public void UpdateNewQuest()
    {
        if (previousQuestQuantity < addedQuest.Count)
        {
            InstantiateQuest(addedQuest[addedQuest.Count - 1]);
        }
    }

    public void InstantiateQuest(CreateQuest thisQuest)
    {
        GameObject showQuest = Instantiate(questPrefab, contenTransform);

        QuestUI ui = showQuest.GetComponent<QuestUI>();
        ui.UpdateUI(thisQuest);
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
 