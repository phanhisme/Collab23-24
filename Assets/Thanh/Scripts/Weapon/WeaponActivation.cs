using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActivation : MonoBehaviour
{
    [SerializeField] GameObject sword;
    [SerializeField] GameObject spear;
    [SerializeField] GameObject hammer;
    [SerializeField] GameObject dagger;
    public bool isSword;
    public bool isSpear;
    public bool isHammer;
    public bool isDagger;

    public void ActiveSword()
    {
        sword.SetActive(true);
        spear.SetActive(false);
        hammer.SetActive(false);
        dagger.SetActive(false);
        isSword = true;
        isSpear = false;
        isHammer = false;
        isDagger = false;
    }

    public void ActiveSpear()
    {
        sword.SetActive(false);
        spear.SetActive(true);
        hammer.SetActive(false);
        dagger.SetActive(false);
        isSword = false;
        isSpear = true;
        isHammer = false;
        isDagger = false;
    }

    public void ActiveHammer()
    {
        sword.SetActive(false);
        spear.SetActive(false);
        hammer.SetActive(true);
        dagger.SetActive(false);
        isSword = false;
        isSpear = false;
        isHammer = true;
        isDagger = false;
    }

    public void ActiveDagger()
    {
        sword.SetActive(false);
        spear.SetActive(false);
        hammer.SetActive(false);
        dagger.SetActive(true);
        isSword = false;
        isSpear = false;
        isHammer = false;
        isDagger = true;
    }
}
