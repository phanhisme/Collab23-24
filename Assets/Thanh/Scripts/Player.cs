using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    WeaponHolder holder;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        holder = GetComponent<WeaponHolder>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            holder.Attack();
        }
    }
}
