using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    private int coinsCount = 0;
    public int travelSpd = 5;
    public TextMeshProUGUI coinText;

    public void Start()
    {
        coinText.text = coinsCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
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
        coinsCount++;
        coinText.text = coinsCount.ToString();
        Debug.Log("collected " + coinsCount + " coins");
    }
}
