using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Skill", fileName = "Skill", order = 1)]
public class SkillScriptable : ScriptableObject
{
    public int itemID;

    public Sprite itemSprite;

    public string itemName;
    public string itemDescription;

    public enum itemType { ACTIVATION, OTU, PASSIVE, CONDITION};
    public itemType item;
}
