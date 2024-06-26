using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private bool checkInRange = false;

    public GameObject shopPanel;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }
    void Update()
    {
        if (checkInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //open shop
                shopPanel.SetActive(true);
                shopManager.SetUp();

                shopManager.currentShopStatus = ShopManager.ShopStatus.OPENED;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        checkInRange = false;
    }

    public void CloseShop()
    {
        shopManager.currentShopStatus = ShopManager.ShopStatus.CLOSED;
        shopPanel.SetActive(false);
    }
}
