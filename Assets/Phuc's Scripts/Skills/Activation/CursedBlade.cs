using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedBlade : MonoBehaviour
{

    [SerializeField] private bool isCursedBladeActive;
    [SerializeField] private int HPDeduction = 1;
    [SerializeField] private int cursedBladeTimer = 6;
    [SerializeField] private GameObject playerPos;
    [SerializeField] private bool isPicked = false;
    PlayerWeaponHolder _weaponHolder;
    public PlayerHealth _healthScript;
    [SerializeField] private float healthAfterUsage;

    private void Start()
    {
        //WeaponHolder _weaponHolder = gameObject.AddComponent<WeaponHolder>() as WeaponHolder;
        //Health _healthScript = gameObject.AddComponent<Health>() as Health;
        _weaponHolder = FindObjectOfType<PlayerWeaponHolder>();
        playerPos = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isPicked)    //need to fix later when dmg is made
            {
                Destroy(gameObject);
                healthAfterUsage = _healthScript.currentHealth - HPDeduction;
                Debug.Log(healthAfterUsage);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(playerPos.transform);
            isPicked = true;
        }
    }
    IEnumerator ActivatingCursedBlade()
    {
        if(_healthScript.currentHealth > 1)
        {
            isCursedBladeActive = true;
        }

        yield return new WaitForSeconds(cursedBladeTimer);
    }
}
