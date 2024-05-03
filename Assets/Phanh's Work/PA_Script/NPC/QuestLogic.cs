using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLogic : MonoBehaviour
{
    public List<CreateReward> rewardType = new List<CreateReward>();
    private CreateReward chosenRewardType;
    public CreateNPC chosenNPC;

    private string questTitle;
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

    private void Start()
    {
        currentStatus = Status.STANDBY;

        RandomQuestData(); //choose a quest type
    }

    public void RandomQuestData()
    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            case 0:
                Debug.Log("Villager");
                questItem = QuestItem.Villagers;
                chosenRewardType = rewardType[0]; //5 currency
                break;

            case 1:
                Debug.Log("Currency");
                questItem = QuestItem.Currency;
                chosenRewardType = rewardType[0]; //5 currency
                break;

            case 2:
                Debug.Log("PU");
                questItem = QuestItem.PickUps;
                chosenRewardType = rewardType[0]; //5 currency
                break;

            case 3:
                Debug.Log("Drop");
                questItem = QuestItem.EnemyDrops;
                chosenRewardType = rewardType[0]; //5 currency
                break;
        }

        //we can add special quest which rewards the player with weapon/activation

        RandomQuestTitle();
        ApplyQuestData();
    }

    public string RandomQuestTitle()
    {
        if (questItem == QuestItem.Villagers)
        {
            int a = RandomNumberForQuestTitle();

            switch (a)
            {
                case 0:
                    return $"Lost in the Wilds";

                case 1:
                    return $"Answer the Desperate Plea";

                case 2:
                    return $"Search for the Missing One";
            }
        }

        else if (questItem == QuestItem.Currency)
        {
            int b = RandomNumberForQuestTitle();

            switch (b)
            {
                case 0:
                    return $"Fruity Harvest";

                case 1:
                    return $"Seeds of Sweet Success";

                case 2:
                    return $"Rags to Riches";
            }
        }

        else if (questItem == QuestItem.PickUps)
        {
            int c = RandomNumberForQuestTitle();

            switch (c)
            {
                case 0:
                    return $"Fruity Harvest";

                case 1:
                    return $"Seeds of Sweet Success";

                case 2:
                    return $"Fortune Through Forage";
            }
        }
        

        return questTitle;
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
        questName.text = RandomQuestTitle();
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
        //int r = Random.Range(0, 4);

        //switch (0)
        //{
        //    case 0:
        //        //return $"<color=blue>{behaviour.thisNPC.NPCName}</color> has a request for you!";
        //        break;
        //}

        NPCBehaviour behaviour = FindObjectOfType<NPCBehaviour>();
        Debug.Log(chosenNPC.NPCName);

        return $"<color=blue>{chosenNPC.NPCName}</color> has a request for you!";
    }

    public int RandomNumberForQuestTitle()
    {

        return Random.Range(0, 2);
    }
}
