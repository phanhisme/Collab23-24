using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    private ExtendedInventory inventory;
    public int travelSpd = 5;

    //private int coinsCount = 0;
    //public TextMeshProUGUI coinText;

    public void Start()
    {
        inventory = FindObjectOfType<ExtendedInventory>();
        //coinText.text = coinsCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();

            QuestManager qm = FindObjectOfType<QuestManager>();
            if (qm.questTrack.Contains(qm.correctQuest("C01"))) //COLLECT FLOWER FOR QUEST
            {
                foreach (QuestTrack quest in qm.questTrack)
                {
                    if (quest.GetItems() == CreateQuest.QuestItem.PickUps)
                    {
                        quest.progressionNumber += 1;
                        qm.CheckNumber(quest, "C01");
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        Coin.OnCoinCollected += CoinManager;
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= CoinManager;
    }

    public void CoinManager()
    {
        //coinsCount++;
        inventory.AddCoinCurrency(1);

        //coinText.text = coinsCount.ToString();
        //Debug.Log("collected " + coinsCount + " coins");
    }
}
