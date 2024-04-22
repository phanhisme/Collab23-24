using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyWeaponHolder : MonoBehaviour
{
    public Transform circle;
    public float radius;
    public Animator anim;
    private bool noAttack;
    public float delayAttack = 0.5f;
    public bool enemyAttacking { get; private set; }
    //public Health health;
    
    
    public void ResetAttackForEnemy()
    {
        enemyAttacking = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
        if(enemyAttacking)
        {
            return;
        }
    }
   
    public void AttackPlayer()
    {
        if (noAttack)
            return;
        anim.SetTrigger("EnemyAttack");
        noAttack = true;
        enemyAttacking = true;
        StartCoroutine(DelayEnemyAttack());
    }
    IEnumerator DelayEnemyAttack()
    {
        yield return new WaitForSeconds(delayAttack);
        noAttack = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectCol()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, radius))
        {
            float enemyDamage = 5;
            col.GetComponent<EnemyHealth>().TestHit(enemyDamage, transform.parent.gameObject);
            Debug.Log(col.name);

        }
    }
}
