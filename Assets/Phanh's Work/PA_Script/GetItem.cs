using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GetItem : MonoBehaviour
{
    public ShopItem item;

    public TextMeshProUGUI itemCost;
    public TextMeshProUGUI itemDes;
    public Image cardBack;

    private void Start()
    {
        itemCost.text = item.itemCost.ToString();
        itemDes.text = item.itemDescription;
        cardBack.sprite = item.cardShowCase;
    }
}
