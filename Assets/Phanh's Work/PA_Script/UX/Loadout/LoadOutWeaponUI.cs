using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadOutWeaponUI : MonoBehaviour
{
    public WeaponSO wp;
    public TextMeshProUGUI weaponName; 
    public Image weaponIcon;

    public void Start()
    {
        weaponName.text = wp.weaponName;
        weaponIcon.sprite = wp.weaponIcon;
    }

    public void HoverOn()
    {
        LoadOutManager loadOutManager = FindObjectOfType<LoadOutManager>();
        loadOutManager.weaponDes.text = wp.weaponDescription;
    }

    public void SetChosen()
    {
        LoadOutManager loadOutManager = FindObjectOfType<LoadOutManager>();
        loadOutManager.so = wp; 
        loadOutManager.weaponDes.text = loadOutManager.so.weaponDescription;
    }
}
