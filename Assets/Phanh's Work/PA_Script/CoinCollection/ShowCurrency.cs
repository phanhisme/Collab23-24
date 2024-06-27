using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCurrency : MonoBehaviour
{
    private ExtendedInventory inventory;
    public TextMeshProUGUI coinText;
    //public Sprite icon;

    //public ShopManager.ShopLocation location;

    private void Start()
    {
        inventory = FindObjectOfType<ExtendedInventory>();
    }

    void Update()
    {
        coinText.text = inventory.stageCoin.ToString();
    }
}
