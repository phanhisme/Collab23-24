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
    
    public QuestManager.Status currentStatus;


   

    //public void CheckingQuest(int amount)
    //{
    //    if (amountCounter == amount)
    //    {
    //        //quest complete
    //        currentStatus = QuestManager.Status.CLAIMABLE;
    //        qm.QuestStatus(currentStatus);
    //    }
    //    else
    //    {
    //        Debug.Log("collected, the amount counted is " + amountCounter);
    //    }
    //}
}
