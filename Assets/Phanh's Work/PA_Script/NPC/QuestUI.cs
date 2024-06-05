using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI description;

    public Image rewardIcon;
    public TextMeshProUGUI rewardAmount;

    public TextMeshProUGUI progression;

    public void UpdateUI(CreateQuest quest)
    {
        nameText.text = quest.questTitle;
        description.text = quest.questDescription;

        rewardIcon.sprite = quest.rewardIcon;
        rewardAmount.text = quest.rewardAmount.ToString();

        progression.text = "0/Requirement";
    }
}
