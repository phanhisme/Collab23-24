using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedBlade : MonoBehaviour
{

    public bool isCursedBladeActive, canActiveCursedBlade;
    [SerializeField] private int HPDeduction = 1;
    [SerializeField] private int cursedBladeTimer = 6;
    [SerializeField] private GameObject playerPos;
    WeaponBase weaponBase;
    public PlayerHealth _healthScript;
    [SerializeField] private float healthAfterUsage;

    public float bleedTimer = 6f;
    public float HpThreshold;
    public float extraBleedDMG;
    private EnemyHealth _enemyHealth;
    private void Start()
    {
        //WeaponHolder _weaponHolder = gameObject.AddComponent<WeaponHolder>() as WeaponHolder;
        //Health _healthScript = gameObject.AddComponent<Health>() as Health;
        weaponBase = FindObjectOfType<WeaponBase>();
        _healthScript = FindObjectOfType<PlayerHealth>();
        _enemyHealth = FindObjectOfType<EnemyHealth>();
        
        playerPos = GameObject.FindWithTag("Player");


        HpThreshold = _enemyHealth.maxHealth * 0.15f;
        extraBleedDMG = _enemyHealth.maxHealth * 0.05f;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Prevent the player to use the cursed blade if the player has 1hp
            if(canActiveCursedBlade && _healthScript.currentHealth > 1)    //need to fix later when dmg is made
            {
                //Destroy(gameObject);
                _healthScript.currentHealth -= HPDeduction;
                StartCoroutine(ActivatingCursedBlade());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Picking up the cursed blade
       if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(playerPos.transform);
            //isPicked = true;
            canActiveCursedBlade = true;
        }
    }
    IEnumerator ActivatingCursedBlade()
    {
        if(_healthScript.currentHealth >= 1 && canActiveCursedBlade)
        {
            isCursedBladeActive = true;
            canActiveCursedBlade = false;
        }
        
        yield return new WaitForSeconds(cursedBladeTimer);
        //Disable cursed blade after 6 seconds
        //isPicked = true;
        isCursedBladeActive = false;
        canActiveCursedBlade = true;

    }
}
