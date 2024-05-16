using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLogic : MonoBehaviour
{
    public List<CreateQuest> rewardType = new List<CreateQuest>();
    private CreateQuest chosenRewardType;
    public CreateNPC chosenNPC;

    public int amountNeeded;

    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDetails;
    public TextMeshProUGUI questIntro;

    public Image rewardImage;
    public TextMeshProUGUI rewardAmount;
    public TextMeshProUGUI progression;

    public Image questStatus;

    public enum Status { ONGOING, STANDBY, CLAIMABLE, CLAIMED }
    public Status currentStatus;

    public enum QuestItem { Currency, PickUps, Villagers, EnemyDrops }
    public QuestItem questItem;

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

    private int QuestItemAmount()
    {
        return amountNeeded;
    }

    void QuestImplementation()
    {

    }

    void ApplyQuestData()
    {
        //questName.text = RandomQuestTitle();
        questDetails.text = FormattedDescription();
        questIntro.text = FormattedIntro();

        rewardImage.sprite = chosenRewardType.rewardIcon;
        rewardAmount.text = chosenRewardType.rewardAmount.ToString();
        //progression.text=chosenScriptable.

        
        // questStatus;
    }

    public string FormattedDescription()
    {
        switch (questItem)
        {
            case QuestItem.Villagers:
                return $"Rescue <b><color=green>{amountNeeded} {questItem}</color></b> from the Forest";

            case QuestItem.Currency:
                return $"Obtain <b><color=green>{amountNeeded} {questItem}</color></b> from the Forest";

            case QuestItem.PickUps:
                return $"Retrieve <b><color=green>{amountNeeded} {questItem}</color></b> from the Forest";

            case QuestItem.EnemyDrops:
                return $"Obtain <b><color=green>{amountNeeded} {questItem}</color></b> from the Forest";
        }
        return "";
    }

    public string FormattedIntro()
    {

        int r = Random.Range(0, 3);

        switch (r)
        {
            case 0:
                return $"<color=blue>{chosenNPC.NPCName}</color> has a request for you!";

            case 1:
                return $"<color=blue>{chosenNPC.NPCName}</color> is seeking for your help...";

            case 2:
                return $"A new commission from <color=blue>{chosenNPC.NPCName}</color> just arrived!";

        }

        return "";
    }

    public int RandomNumberForQuestTitle()
    {

        return Random.Range(0, 2);
    }
}
