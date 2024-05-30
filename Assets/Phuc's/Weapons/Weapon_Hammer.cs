using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hammer : WeaponBase
{
    //SLAM AOE VARIABLES
    public float maxChargeTime = 3f; 
    public float minAOERadius = 1f; 
    public float maxAOERadius = 5f; 
    public float damage = 50f; 

    private float chargeTimer = 0f;
    private bool isCharging = false; 
    private bool isAttackTriggered = false;
    private bool Hammer_CanAttack = true;
    public GameObject AOEVisual;

    EnemyHealth _enemyHealth;

    //SWING ATTACK VARIABLES
    public float swingRadius = 1.5f; // Radius of the swing attack

    public float swingDuration = 0.5f; // Duration of the swing animation
    public LayerMask enemyLayer; // Layer mask for enemy detection

    private bool isSwinging = false; // Flag to track if the player is currently swinging

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void Attack(Animator animator)
    {
        

    }
    //TODO: HAMMER SLAM ATTACK 
    void Update()
        {
            if (Input.GetMouseButton(0) && Hammer_CanAttack) 
            {
                isCharging = true;
                chargeTimer = 0f;
            }

            if (Input.GetMouseButtonUp(0) && Hammer_CanAttack) 
            {
                if (isCharging)
                {
                    isAttackTriggered = true;
                    isCharging = false;
                    Hammer_CanAttack = false;
                }
            }
        if (Input.GetMouseButtonDown(0) && !isSwinging)
        {
            isSwinging = true;
            animator.SetTrigger("Swing");
            Invoke("PerformSwing", swingDuration);
        }

        if (isCharging && chargeTimer > 1)
            {
                chargeTimer += Time.deltaTime;
            }

            if (isAttackTriggered)
            {
                // Instantiate the AOE visual effect at the player's position
                GameObject visualEffect = Instantiate(AOEVisual, transform.position, Quaternion.identity);
                Destroy(visualEffect, 1f);
             StartCoroutine(Hammer_AttackDelay());
                    
            
                // Calculate AOE radius based on charge time
                float chargePercentage = Mathf.Clamp01(chargeTimer / maxChargeTime);
                float AOE_radius = Mathf.Lerp(minAOERadius, maxAOERadius, Mathf.Clamp01(chargeTimer / maxChargeTime));


            // Detect enemies within the AOE radius and apply damage
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, AOE_radius);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Enemy"))
                    {
                    // Apply damage to the enemy
                    /*collider.GetComponent<EnemyHealth>().TestHit();*/
                    }
                }

                // Reset flags
                isAttackTriggered = false;
            }
        }

        // Draw gizmos to visualize AOE radius in the Unity editor
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, maxAOERadius);
        }

    IEnumerator Hammer_AttackDelay()
    {
        Hammer_CanAttack = false;
        yield return new WaitForSeconds(delay);
        Hammer_CanAttack = true;
    }
//TODO: HAMMER SWING ATTACK
    void PerformSwing()
    {
        // Detect enemies within the swing radius
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, swingRadius, enemyLayer);

        // Deal damage to each enemy within the swing radius
        foreach (Collider2D enemy in hitEnemies)
        {
          /*  // Apply damage to the enemy
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);*/
        }

        isSwinging = false; // Reset swinging flag
    }

   
}



