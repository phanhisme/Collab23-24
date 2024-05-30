using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedBlade : MonoBehaviour
{

    public bool isCursedBladeActive, canActiveCursedBlade;
    [SerializeField] private int HPDeduction = 1;
    [SerializeField] private int cursedBladeTimer = 6;
    [SerializeField] private GameObject playerPos;
    PlayerWeaponHolder _weaponHolder;
    public PlayerHealth _healthScript;
    private EnemyHealth _enemyHealth;
    
    
    [SerializeField] private float healthAfterUsage;

    //BLEED
    public float HpThreshold;
    public int bleedTimer = 6;
    public float extraBleedDMG;
    
    
    private void Start()
    {
        //WeaponHolder _weaponHolder = gameObject.AddComponent<WeaponHolder>() as WeaponHolder;
        //Health _healthScript = gameObject.AddComponent<Health>() as Health;
        
        _weaponHolder = FindObjectOfType<PlayerWeaponHolder>();
        _healthScript = FindObjectOfType<PlayerHealth>();
        _enemyHealth = FindObjectOfType<EnemyHealth>();
        
        playerPos = GameObject.FindWithTag("Player");
        
        //Execute when the enemy's health is below 15%
        HpThreshold = _enemyHealth.maxHealth * 0.15f;
        extraBleedDMG = _enemyHealth.maxHealth * 0.05f;
        bleedTimer = 6;
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

        isCursedBladeActive = false;
        canActiveCursedBlade = true;
    }
}