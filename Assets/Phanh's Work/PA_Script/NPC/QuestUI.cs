using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public CreateQuest quest;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI description;

    public Image rewardIcon;
    public TextMeshProUGUI rewardAmount;

    public TextMeshProUGUI progression;

    public Status currentStatus;
    public enum Status { Unclaimable,Claimable };

    public void UpdateUI()
    {
        nameText.text = quest.questTitle;
        description.text = quest.questDescription;

        rewardIcon.sprite = quest.rewardIcon;
        rewardAmount.text = quest.rewardAmount.ToString();
    }

    public void ClaimQuest()
    {
        if (currentStatus == Status.Claimable)
        {
            ExtendedInventory inven = FindObjectOfType<ExtendedInventory>();
            inven.AddCoinCurrency(quest.rewardAmount);

            progression.text = "Claimed";

            QuestManager qm = FindObjectOfType<QuestManager>();
            qm.questObject.Remove(this.gameObject);
            qm.addedQuest.Remove(quest);

            currentStatus = Status.Unclaimable;
        }
    }
}
