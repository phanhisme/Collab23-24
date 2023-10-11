using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    public bool IsAttacking { get; private set; }
    public Transform circle;
    public float radius;
    private Camera mainCam;
    private Vector2 mousePos;
    public WeaponHolder weaponHolder;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public void ResetAttack()
    {
        IsAttacking = false;

    }
    private void FixedUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
    }
    private void Update()
    {
        if (IsAttacking)
        {
            return;
        }
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        transform.right = direction;
        Vector2 scale = transform.localScale;
        if(direction.x < 0)
        {
            scale.y = -1;
        }
        else if( direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;  

        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        } 
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }
    public void Attack()
    {
        if(attackBlocked)
        {
            return;
        }
        animator.SetTrigger("Attack");
        IsAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectCol()
    {
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(circle.position,radius))
        {
            Debug.Log(collider.name);
        }
    }
}
