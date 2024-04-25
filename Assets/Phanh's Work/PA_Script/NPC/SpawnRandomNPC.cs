using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnRandomNPC : MonoBehaviour
{
    public List<CreateNPC> allNPC = new List<CreateNPC>();
    public GameObject npcHolder;
    public GameObject textObject;

    private enum DayCycle{ DAY, NIGHT};
    private DayCycle currentCycle;

    void Start()
    {
        currentCycle = DayCycle.DAY;
        DayCycleControl();
    }

    void DayCycleControl()
    {
        if (currentCycle == DayCycle.DAY)
        {
            SpawnNPC(); //if the cycle of the day (at base is Day)
        }
        else
        {
            
            //everyone goes to sleep
            //darker background and fire will turn on as light
        }
    }

    void SpawnNPC()
    {
        //at the start of day, a random npc will appear at the base
        int randomValue = Random.Range(0, allNPC.Count);

        //replace the existing npc to the data of the random npc
        CreateNPC thisScriptable = allNPC[randomValue];

        TextMeshPro text = textObject.GetComponent<TextMeshPro>();
        text.text = thisScriptable.NPCName;
    }
}
