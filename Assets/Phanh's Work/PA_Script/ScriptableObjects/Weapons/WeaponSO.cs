using UnityEngine;

[CreateAssetMenu(fileName = "weapon.asset", menuName = "Spawners/Weapons")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public string weaponDescription;

    public Sprite weaponIcon;
}
