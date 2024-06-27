using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public List<CreateQuest> addedQuest = new List<CreateQuest>();
    public List<GameObject> questObject = new List<GameObject>();

    public GameObject questPrefab;
    public Transform contenTransform;

    public TextMeshProUGUI questNumber;
    public int maxQuest = 5;

    public enum Status { ONGOING, STANDBY, CLAIMABLE, CLAIMED }

    public void Start()
    {
        GameObject uiItems = this.transform.GetChild(0).gameObject;
        uiItems.gameObject.SetActive(false);

        questNumber.text = addedQuest.Count.ToString() + "/" + maxQuest.ToString();
    }

    public void QuestStatus(Status questStatus)
    {
        //newly accepted quest will automatically become on going upon acception
        switch (questStatus)
        {
            case Status.ONGOING:

                break;

            case Status.STANDBY:
                break;

            case Status.CLAIMABLE:
                break;

            case Status.CLAIMED:
                break;
        }
    }

    public void UpdateNewQuest()
    {
        InstantiateQuest(addedQuest[addedQuest.Count - 1]);
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
            chosenQuest.currentStatus = Status.ONGOING;
        }
        else
        {
            //find existing quest in the 
            chosenQuest.currentStatus = Status.ONGOING;
        } 
    }

    //public
}
 