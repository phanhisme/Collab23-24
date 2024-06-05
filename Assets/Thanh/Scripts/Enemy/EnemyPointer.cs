using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointer : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform circle;
    public float radius;
    public EnemyWeaponHolder holder;
    [SerializeField] Transform player;
    Invisibility invisibility;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        invisibility = FindObjectOfType<Invisibility>();
    }
    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectPlayer()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, radius))
        {
            //Debug.Log("a");
            if (col.gameObject.tag == "Player" && invisibility.isActivated == false)
            {
                Vector2 direction = player.position - transform.position;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
                holder.AttackPlayer();
                //Debug.Log(".");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.ColDamage();
        }
        if (playerHealth.currentHealth <= 0)
        {
            playerHealth.Dead();
        }
    }
}
