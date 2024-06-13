using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellItem : MonoBehaviour
{
    public InventoryItem thisItem;

    public void SellThisItem()
    {
        ExtendedInventory inventory = FindObjectOfType<ExtendedInventory>();
        ShopManager shop = FindObjectOfType<ShopManager>();

        if (shop.sceneIndex == 1) //can sell in shop at base but not in stage
        {
            inventory.AddGoldCurrency(thisItem.item.price);
            inventory.MinusNumber(thisItem.item);

            if (thisItem.GetInventoryNumber() >= 1)
            {
                TextMeshProUGUI inventoryText = GetComponentInChildren<TextMeshProUGUI>();
                inventoryText.text = thisItem.GetInventoryNumber().ToString();
            }

            else
                Destroy(this.gameObject);
        }
    }
}
