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
