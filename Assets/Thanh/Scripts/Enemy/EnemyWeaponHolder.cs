using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyWeaponHolder : MonoBehaviour
{
    public Transform circle;
    public float radius;
    public Animator anim;
    [SerializeField] private bool noAttack;
    public float delayAttack = 0.5f;
    public float enemyDamage = 5;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private AnimationEvent animEvent;
    private Enemy enemy;
    public bool enemyAttacking { get; private set; }
    
    

    // Start is called before the first frame update
    void Start()
    {
        animEvent.OnEventTriggered += DetectCol;
        enemy = GetComponentInParent<Enemy>();
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
        if (noAttack && !enemy._isWithinStrikingDistance)
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
        
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, radius, playerMask))
        {
           
            col.GetComponent<PlayerHealth>().TestHit(enemyDamage, transform.gameObject);
            Debug.Log(col);
        }
    }
    public void ResetAttackForEnemy()
    {
        enemyAttacking = false;
    }
}
