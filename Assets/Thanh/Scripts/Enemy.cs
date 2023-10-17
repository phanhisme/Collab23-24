using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform circle;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    private void DetectPlayer()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, radius))
        {
            if(col.gameObject.tag == "Player")
            {

            }
        }
    }
}
