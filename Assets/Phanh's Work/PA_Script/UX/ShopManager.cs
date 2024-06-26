using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    //inventory
    public GameObject invenItems;
    public Transform _itemHolder;

    //shopkeeper
    public GameObject iconObject;
    public Sprite hippoImage;
    public Sprite crocImage;

    public TextMeshProUGUI shopkeeperName;
    public TextMeshProUGUI welcomeMessage;

    public Sprite goldIcon;
    public Sprite coinIcon;

    public Image currencyIcon;
    public TextMeshProUGUI currencyText;

    public GameObject currencyRemain;

    //keep track of whether player is in stage or scene to adjust the set up accordingly
    public ShopLocation currentLocation;
    public ShopStatus currentShopStatus;

    public enum ShopLocation { BASE, STAGE };
    public enum ShopStatus { OPENED, CLOSED };

    public void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        DashStamina playerStamina = player.GetComponent<DashStamina>();

        if (currentShopStatus == ShopStatus.OPENED)
        {
            movement.enabled = false;
            playerStamina.enabled = false;
        }
        else if (currentShopStatus == ShopStatus.CLOSED)
        {
            movement.enabled = true;
            playerStamina.enabled = true;
        }
    }

    public void SetUp()
    {
        //lock player move

        switch (currentLocation)
        {
            case ShopLocation.BASE:
                iconObject.GetComponent<Image>().sprite = hippoImage;
                shopkeeperName.text = "Hippo";
                welcomeMessage.text = GetHippoString();

                GetInventory();

                currencyIcon.sprite = goldIcon;
                currencyText.text = GetCurrencies().ToString();
                break;

            case ShopLocation.STAGE:
                iconObject.GetComponent<Image>().sprite = crocImage;
                shopkeeperName.text = "Crocodile";
                welcomeMessage.text = GetCrocodileString();

                GetInventory();

                currencyIcon.sprite = goldIcon;
                currencyText.text = GetCurrencies().ToString();
                break;
        }
    }

    public void GetInventory()
    {
        ExtendedInventory inventory = FindObjectOfType<ExtendedInventory>();
        if (inventory.collectedItems.Count >= 1)
        {
            foreach (InventoryItem item in inventory.pickUpItems)
            {
                //spawn the item
                GameObject newObj = Instantiate(invenItems, _itemHolder);

                //get script
                SellItem sellItem = newObj.GetComponent<SellItem>();
                sellItem.thisItem = item;

                //get number of item in inventory
                TextMeshProUGUI quanText = newObj.GetComponentInChildren<TextMeshProUGUI>();
                quanText.text = item.GetInventoryNumber().ToString();

                //get sprite
                Image sprite = newObj.GetComponent<Image>();
                sprite.sprite = item.item.itemIcon;
            }
        }
    }

    public int GetCurrencies()
    {
        ExtendedInventory inventory = FindObjectOfType<ExtendedInventory>();
        switch (currentLocation)
        {
            case ShopLocation.BASE:
                return inventory.Gold;

            case ShopLocation.STAGE:
                return inventory.stageCoin;

            default:
                return 0;
        }
    }

    public string GetHippoString()
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                return "Welcom to Hippo's! Choose whatever you like for the finest price!";

            case 1:
                return "If you want to sell your items for some quick money, simply click on the item in your inventory!";

            case 2:
                return "Welcome to Hippo's! I've got some great quality items in stock just for you!";

            default:
                return "";
        }
    }

    public string GetCrocodileString()
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                return "Croc... Crocodile has goods for you.";

            case 1:
                return "Croc... Coins.";

            case 2:
                return "Croc... sleepy, ZzzzZZzz...";

            default:
                return "";
        }
    }
}
