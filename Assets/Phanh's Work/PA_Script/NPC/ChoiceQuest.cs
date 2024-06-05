using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceQuest : MonoBehaviour
{
    public NPCBehaviour npc;
    
    public void AcceptQuest()
    {
        npc.AcceptQuest();
    }

    public void DeclineQuest()
    {
        npc.DeclineQuest();
    }
}