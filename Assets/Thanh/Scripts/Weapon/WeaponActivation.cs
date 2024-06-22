using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActivation : MonoBehaviour
{
    [SerializeField] GameObject sword;
    [SerializeField] GameObject spear;
    [SerializeField] GameObject hammer;
    [SerializeField] GameObject dagger;

    public void ActiveSword()
    {
        sword.SetActive(true);
        spear.SetActive(false);
        hammer.SetActive(false);
        dagger.SetActive(false);
    }

    public void ActiveSpear()
    {
        sword.SetActive(false);
        spear.SetActive(true);
        hammer.SetActive(false);
        dagger.SetActive(false);
    }

    public void ActiveHammer()
    {
        sword.SetActive(false);
        spear.SetActive(false);
        hammer.SetActive(true);
        dagger.SetActive(false);
    }

    public void ActiveDagger()
    {
        sword.SetActive(false);
        spear.SetActive(false);
        hammer.SetActive(false);
        dagger.SetActive(true);
    }
}
