using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLogic : MonoBehaviour
{
    public CreateNPC chosenNPC;

    public int amountNeeded;

    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDetails;
    public TextMeshProUGUI questIntro;

    public Image rewardImage;
    public TextMeshProUGUI rewardAmount;
    public TextMeshProUGUI progression;

    public List<Sprite> statusSprite = new List<Sprite>();

    public enum Status { ONGOING, STANDBY, CLAIMABLE, CLAIMED }
    public Status currentStatus;

    

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
        questIntro.text = FormattedIntro();
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
}
