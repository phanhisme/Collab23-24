using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UniversalPickUps : MonoBehaviour, IPickUps
{
    //get data for scriptable objects here

    //pick up anything! //from coin script but i dont want to mess that up (yet)

    //system is used for texturing
    //Action:Zero argument delegate used by UnityEvents.
    //reate dynamic functionality in your scripts, allowing to call multiple functions
    //Since actions have no arguments, functions they call must also have no arguments

    public Items thisItem;

    public Items Item { get{ return thisItem; } }
    public string ItemName { get { return thisItem.itemName; } }

    public static event Action OnCollected;
    private Rigidbody2D rb;

    private CollectItems collectItems;
    private float travelSpeed;

    private bool targetDetected;
    Vector3 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collectItems = FindObjectOfType<CollectItems>();
        travelSpeed = collectItems.travelSpd;
    }

    public void Collect()
    {
        //destroy go and stop the running action
        Destroy(gameObject);
        OnCollected?.Invoke();
    }

    private void FixedUpdate()
    {
        if (targetDetected)
        {
            //tell the coins where to go
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * travelSpeed;
        }
    }

    public void FindTarget(Vector3 position)
    {
        targetPosition = position;
        targetDetected = true;
    }
}
