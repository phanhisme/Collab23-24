using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLogic : MonoBehaviour
{
    public int amountCounter;

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

    public void Activating()
    {
        amountCounter = 0;
    }

    public void CheckingQuest(int amount)
    {
        if (amountCounter == amount)
        {
            //quest complete
            currentStatus = Status.CLAIMABLE;
            QuestStatus(currentStatus);
        }
        else
        {
            Debug.Log("collected, the amount counted is " + amountCounter);
        }
    }
}
