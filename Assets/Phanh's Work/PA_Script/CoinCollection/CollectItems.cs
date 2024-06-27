using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CollectItems : MonoBehaviour
{
    private ExtendedInventory inventory;
    public int travelSpd = 5;

    public void Start()
    {
        inventory = FindObjectOfType<ExtendedInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickUps collectible = collision.GetComponent<IPickUps>();

        if (collectible != null)
        {
            if (!inventory.collectedItems.Contains(collectible.Item)) //check if collected item has this item yet
            {
                int startInt = 1;
                inventory.GetData(collectible.Item, startInt);
            }
            else
            {
                //Item existedItem
                inventory.AddNumber(collectible.Item);
            }

            collectible.Collect();

            QuestManager qm = FindObjectOfType<QuestManager>();
            if (qm.questTrack.Contains(qm.correctQuest("P01"))) //COLLECT FLOWER FOR QUEST
            {
                foreach (QuestTrack quest in qm.questTrack)
                {
                    if (quest.GetItems() == CreateQuest.QuestItem.PickUps)
                    {
                        quest.progressionNumber += 1;
                        qm.CheckNumber(quest, "P01");
                    }
                }
            }
        }
    }

    

    //private void OnEnable()
    //{
    //    UniversalPickUps.OnCollected += ItemManager;
    //}

    //private void OnDisable()
    //{
    //    UniversalPickUps.OnCollected -= ItemManager;
    //}

    //public void ItemManager()
    //{
    //    //coinsCount++;
    //    //coinText.text = coinsCount.ToString();
    //    //Debug.Log("collected " + coinsCount + " coins");
    //}
}
