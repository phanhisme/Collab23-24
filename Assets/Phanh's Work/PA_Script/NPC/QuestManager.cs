using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public List<CreateQuest> addedQuest = new List<CreateQuest>();
    public List<GameObject> questObject = new List<GameObject>();
    public List<QuestTrack> questTrack = new List<QuestTrack>();

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
        questObject.Add(showQuest);

        QuestUI ui = showQuest.GetComponent<QuestUI>();
        ui.quest = thisQuest;
        ui.UpdateUI();
    }

    public void CheckNumber(QuestTrack quest, string ID)
    {
        int number = quest.GetProgressionNumber();
        foreach (GameObject questObject in questObject)
        {
            QuestUI ui = questObject.GetComponent<QuestUI>();
            if (ui.quest.questID == ID)
            {
                if(number < quest.GetQuest().questAmount)
                {
                    ui.UpdateUI();
                    ui.progression.text = quest.GetProgressionNumber() + "/" + quest.createQuest.questAmount;
                }

                else if (number >= quest.GetQuest().questAmount)
                {
                    //QUEST FINISHED
                    ui.progression.text = "Claim";

                    //ENABLE CLAIM
                    ui.currentStatus = QuestUI.Status.Claimable;
                }
            }
        }
    }

    public QuestTrack correctQuest(string questID)
    {
        foreach(QuestTrack questTrackItem in questTrack)
        {
            if (questTrackItem.GetQuest().questID == questID)
            {
                return questTrackItem;
            }
        }
        return null;
    }
}
 