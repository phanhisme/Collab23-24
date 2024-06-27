using UnityEngine;

[CreateAssetMenu(fileName = "shopItem.asset", menuName = "Spawners/ShopItem")]
public class ShopItem : ScriptableObject
{
    //public string itemName;
    public string itemDescription;

    //public Sprite itemIcon;
    public Sprite cardShowCase;

    public int itemCost;

    public itemType type;
    public enum itemType { Passive, Conditional, OTU, Activation};
}
