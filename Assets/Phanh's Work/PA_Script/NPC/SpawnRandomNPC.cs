using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnRandomNPC : MonoBehaviour
{
    public List<CreateNPC> allNPC = new List<CreateNPC>();

    public GameObject npcHolder;
    public GameObject textObject;

    private enum DayCycle{ DAY, NIGHT};
    private DayCycle currentCycle;

    public string Tname;


    void Start()
    {
        currentCycle = DayCycle.DAY;
        DayCycleControl();
    }

    void DayCycleControl()
    {
        if (currentCycle == DayCycle.DAY)
        {
            SpawnNPC(); //if the cycle of the day (at base is Day) //can use int if spawn more than 1
           
            
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
        int randomValue = Random.Range(0, allNPC.Count); //can random spawn location

        //replace the existing npc to the data of the random npc
        CreateNPC thisScriptable = allNPC[randomValue];

        TextMeshPro text = textObject.GetComponent<TextMeshPro>();
        text.text = thisScriptable.NPCName;

        NPCBehaviour behaviour = FindObjectOfType<NPCBehaviour>();
        behaviour.thisNPC = thisScriptable;

        QuestLogic logic = FindObjectOfType<QuestLogic>();
        logic.chosenNPC = thisScriptable;

        //logic.RandomQuestData();
    }
}
