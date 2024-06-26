using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedInventory : MonoBehaviour
{
    public int stageCoin;
    public int Gold;

    public List<Items> collectedItems = new List<Items>();
    public List<InventoryItem> pickUpItems = new List<InventoryItem>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGoldCurrency(int currency)
    {
        Gold += currency;
    }

    public void AddCoinCurrency(int currency)
    {
        stageCoin += currency;
    }

    public void GetData(Items itemData, int itemNumber)
    {
        pickUpItems.Add(new InventoryItem(itemData, itemNumber));
        collectedItems.Add(itemData);
    }

    public void AddNumber(Items item)
    {
        InventoryItem slot = FindCorrectScriptable(item);
        slot.AddQuantity(1);
    }

    public void MinusNumber(Items item)
    {
        InventoryItem slot = FindCorrectScriptable(item);
        slot.SubQuantity(1);
    }

    public InventoryItem FindCorrectScriptable(Items items)
    {
        foreach (InventoryItem i in pickUpItems)
        {
            if (i.GetItems() == items)
                return i;
        }

        return null;
    }
}
