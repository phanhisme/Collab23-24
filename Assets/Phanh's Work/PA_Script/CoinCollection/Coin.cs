using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour,ICollectible //interface
{
    //system is used for texturing
    //Action:Zero argument delegate used by UnityEvents.
    //reate dynamic functionality in your scripts, allowing to call multiple functions
    //Since actions have no arguments, functions they call must also have no arguments

    public static event Action OnCoinCollected;
    private Rigidbody2D rb;

    private CollectCoin collectCoin;
    private float travelSpeed;

    private bool targetDetected;
    Vector3 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collectCoin = FindObjectOfType<CollectCoin>();
        travelSpeed = collectCoin.travelSpd;
    }

    public void Collect()
    {
        //destroy go and stop the running action
        Destroy(gameObject);
        OnCoinCollected?.Invoke();
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
