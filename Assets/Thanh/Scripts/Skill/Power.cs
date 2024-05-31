using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    WeaponBase weaponBase;
    private void Start()
    {
        weaponBase = FindObjectOfType<WeaponBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            weaponBase.power += weaponBase.power * 0.2f;
            Destroy(gameObject);
        }
    }
}
