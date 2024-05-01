using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLogic : MonoBehaviour
{
    public List<CreateQuest> allQuest = new List<CreateQuest>();

    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDetails;
    public TextMeshProUGUI questIntro;

    public Image rewardImage;
    public TextMeshProUGUI rewardAmount;
    public TextMeshProUGUI progression;

    public Image questStatus;

    public enum Status { ONGOING, STANDBY, CLAIMABLE, CLAIMED }
    public Status currentStatus;

    private NPCBehaviour behaviour;

    private void Start()
    {
        behaviour = FindObjectOfType<NPCBehaviour>();
        currentStatus = Status.STANDBY;
        
        SpawnRandomQuest(); //choose a quest
    }

    public void GetQuestData()
    {
        
    }
    public void SpawnRandomQuest()
    {
        int rand = Random.Range(0, allQuest.Count);

        behaviour.chosenScriptable = allQuest[rand];

        //chosenScriptable = quest;
        //allQuest[rand] = chosenScriptable;

        ApplyQuestData();
    }

    void ApplyQuestData()
    {
        questName.text = behaviour.chosenScriptable.questName;
        questDetails.text = FormattedDescription();
        //questIntro.text = FormattedIntro();

        rewardImage.sprite = behaviour.chosenScriptable.rewardIcon;
        rewardAmount.text = behaviour.chosenScriptable.rewardAmount.ToString();
        //progression.text=chosenScriptable.

        // questStatus;
    }

    public string FormattedDescription()
    {
        switch (behaviour.chosenScriptable.questItem)
        {
            case CreateQuest.QuestItem.Villagers:
                return $"Rescue <b><color=green>{behaviour.chosenScriptable.amountNeeded} {behaviour.chosenScriptable.questItem}</color></b> from the Forest";

            case CreateQuest.QuestItem.Currency:
                return $"Obtain <b><color=green>{behaviour.chosenScriptable.amountNeeded} {behaviour.chosenScriptable.questItem}</color></b> from the Forest";

            case CreateQuest.QuestItem.PickUps:
                return $"Retrieve <b><color=green>{behaviour.chosenScriptable.amountNeeded} {behaviour.chosenScriptable.questItem}</color></b> from the Forest";

            case CreateQuest.QuestItem.EnemyDrops:
                return $"Obtain <b><color=green>{behaviour.chosenScriptable.amountNeeded} {behaviour.chosenScriptable.questItem}</color></b> from the Forest";
        }
        return "";
    }

    public string FormattedIntro()
    {
        //int r = Random.Range(0, 4);

        switch (0)
        {
            case 0:
                //return $"<color=blue>{behaviour.thisNPC.NPCName}</color> has a request for you!";
                break;
        }

        return $"<color=blue>{behaviour.thisNPC.NPCName}</color> has a request for you!";
    }
}
