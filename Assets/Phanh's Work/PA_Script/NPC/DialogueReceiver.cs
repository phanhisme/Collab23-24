using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueReceiver : MonoBehaviour
{
    public TextMeshProUGUI speakerName;
    public TextMeshProUGUI diaText;
    public Animator anim;

    public GameObject dialogueBox;

    private void Start()
    {
        //dialogueBox.SetActive(false);
    }


    public void AcceptQuest()
    {

    }

    public void DeclineQuest()
    {

    }
}