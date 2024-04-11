using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthyMeal : MonoBehaviour
{
    [SerializeField] private bool isPicked = false;
    Health healthScript;
    
    public Transform player;
    public GameObject playerObj;
    private void Awake()
    {
        healthScript = FindObjectOfType<Health>();
    }
    private void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameObject.transform.SetParent(player);
            isPicked = true;
        }
    }
    private void Update()
    {
        //For testing purposes only
        if(Input.GetKeyDown(KeyCode.E) && isPicked)
        {
            
            healthScript.maxHealth = healthScript.maxHealth + 1;
            Destroy(this.gameObject);
        }
    }
}
