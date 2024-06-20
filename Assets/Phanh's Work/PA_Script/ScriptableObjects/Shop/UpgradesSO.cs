using UnityEngine;

[CreateAssetMenu(fileName = "weapon.asset", menuName = "Spawners/Weapons")]
public class UpgradesSO : ScriptableObject
{
    public int upgradeID;

    public string upgradeName;
    public string upgradeDescription;

    public Sprite upgradeIcon;

    public int purchaseAmount;
    public Currency usedCurrency;

    public enum Currency{Gold, StageCoins };
}
