using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private Collider2D col;
    private bool hasSpoken = false; //has spoken in that day

    public CreateNPC thisNPC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hi");
        }
    }

    private void Start()
    {
        //get data for this npc


    }

}
