using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    PlayerWeaponHolder pHolder;
    private void Start()
    {
        pHolder  = FindObjectOfType<PlayerWeaponHolder>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pHolder.playerDamage = pHolder.playerDamage + pHolder.playerDamage * 0.2f;
            Destroy(gameObject);
        }
    }
}
