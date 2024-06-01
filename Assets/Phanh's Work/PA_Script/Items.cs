using UnityEngine;

[CreateAssetMenu(fileName = "item.asset", menuName = "Spawners/Drops")]
public class Items : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public itemType type;
    public enum itemType { DROPS, PICKUPS };
}
