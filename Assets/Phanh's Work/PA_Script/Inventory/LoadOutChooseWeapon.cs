using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LoadOutChooseWeapon : MonoBehaviour
{
    public WeaponSO thisWeapon;
    public Image weaponImage;
    public TextMeshProUGUI nameText;

    private void Start()
    {
        weaponImage.sprite = thisWeapon.weaponIcon;

        nameText.text = thisWeapon.weaponName;
    }
    

    public void ChooseSword(WeaponSO sword)
    {
        //playerscript.weapon=sword;
    }

    public void ChooseSpear(WeaponSO spear)
    {
        //
    }

    public void ChooseDagger(WeaponSO dagger)
    {
        //
    }

    public void ChooseHammer(WeaponSO hammer)
    {
        //
    }
}
