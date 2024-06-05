using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnRandomNPC : MonoBehaviour
{
    public GameObject npcToSpawn;
    public GameObject[] waypoints;
    public GameObject textObject;
    public Transform npcHolder;

    private enum DayCycle{ DAY, NIGHT};
    private DayCycle currentCycle;

    void Start()
    {
        currentCycle = DayCycle.DAY;
        DayCycleControl();

        SpawnNPC();
    }

    void DayCycleControl()
    {
        if (currentCycle == DayCycle.DAY)
        {
             //if the cycle of the day (at base is Day) //can use int if spawn more than 1
        }
        else if (currentCycle == DayCycle.NIGHT)
        {
            //everyone goes to sleep
            //darker background and fire will turn on as light
        }
    }

    void SpawnNPC()
    {
        Debug.Log("spawning npc");
        int randomWaypoints = Random.Range(0, waypoints.Length);
        GameObject chosenWaypoints = waypoints[randomWaypoints];

        GameObject thisNPC = Instantiate(npcToSpawn, chosenWaypoints.transform.position, Quaternion.identity) as GameObject;
        thisNPC.transform.parent = npcHolder;
    }
}
