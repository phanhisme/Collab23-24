using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    [SerializeField] public Items item;
    [SerializeField] public int itemCount;

    public InventoryItem(Items itemScriptable, int count)
    {
        item = itemScriptable;
        itemCount = count;
    }

    public Items GetItems() { return item; }
    public int GetInventoryNumber() { return itemCount; }
    public void AddQuantity(int _quantity) { itemCount += _quantity; }
    public void SubQuantity(int _quantity) { itemCount -= _quantity; }
}
