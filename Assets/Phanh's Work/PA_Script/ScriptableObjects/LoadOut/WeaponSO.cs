using UnityEngine;

[CreateAssetMenu(fileName = "weapon.asset", menuName = "Spawners/Weapons")]
public class WeaponSO : ScriptableObject
{
    public int weaponID;

    public string weaponName;
    public string weaponDescription;

    public Sprite weaponIcon;
}
