using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CollectItems : MonoBehaviour
{
    public List<Items> collectedItems = new List<Items>();
    public List<Item> pickUpItems = new List<Item>();

    [System.Serializable]
    public struct Item
    {
        public string itemName;
        public int itemCount;
        public Items collectedItem;
    }
    
    public int travelSpd = 5;
    //public TextMeshProUGUI coinText;

    public void Start()
    {
        //coinText.text = coinsCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickUps collectible = collision.GetComponent<IPickUps>();

        if (collectible != null)
        {
            if (!collectedItems.Contains(collectible.Item)) //check if collected item has this item yet
            {
                int startInt = 0;
                GetData(startInt,collectible.Item);
            }
            else
            {
                //Item existedItem
                Item itemToFind = FindCorrectItem(pickUpItems,collectible);

                itemToFind.itemCount = 1;

            }

            Debug.Log("HA");

            collectible.Collect();
        }
    }

    private void OnEnable()
    {
        UniversalPickUps.OnCollected += ItemManager;
    }

    private void OnDisable()
    {
        UniversalPickUps.OnCollected -= ItemManager;
    }

    public void ItemManager()
    {
        //coinsCount++;
        //coinText.text = coinsCount.ToString();
        //Debug.Log("collected " + coinsCount + " coins");

        
    }

    public void GetData(int itemNumber, Items itemData)
    {
        //if not, create struct
        Item newItem = new Item();

        newItem.itemName = itemData.itemName;
        newItem.itemCount = itemNumber;
        newItem.collectedItem = itemData;

        //add
        collectedItems.Add(newItem.collectedItem);
        pickUpItems.Add(newItem);
    }

    public Item FindCorrectItem(List<Item> itemList,IPickUps pickUp)
    {
        foreach (Item i in itemList)
        {
            if (i.collectedItem == pickUp.Item)
                return i;
        }

        return new Item();
    }
}
