using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCBehaviour : MonoBehaviour
{
    public List<CreateNPC> allNPC = new List<CreateNPC>();
    public TextMeshPro nameText;

    public Collider2D col;
    
    //friendship - if any
    private bool hasSpoken = false; //has spoken in that day

    private bool hasAcceptedQuest = false;
    private bool hasTakenQuest = false; //ask if the player has take a quest
    private bool checkInRange = false;

    //kind of misled - meaning this npc has a quest for the player
    private bool interacting = false;

    public CreateNPC thisNPC; //npc scriptable - we can add NPC trait - to randomize what they might say from different traits

    public bool isAvailableForQuest = false;

    public List<CreateQuest> allQuest = new List<CreateQuest>();
    public CreateQuest quest;

    public GameObject idleChat; //showing a speech bubble above the player
    public TextMeshPro chatText;

    private int path;

    public TextMeshProUGUI timerText;
    public float popChatCooldown = 10.0f;
    public float currentTime = 0f;

    public enum Status { TALKING, IDLE};
    public Status currentStatus;

    //ui
    public GameObject questAndDiaPanel;
    public GameObject questUI;
    public GameObject dialogueBox;

    //player
    GameObject player;
    PlayerMovement movement;
    DashStamina playerStamina;

    private void Start()
    {
        //references
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<PlayerMovement>();
        playerStamina = player.GetComponent<DashStamina>();

        questAndDiaPanel = GameObject.Find("Quest&Dialogue");
        questUI = questAndDiaPanel.transform.GetChild(1).gameObject;
        dialogueBox = questAndDiaPanel.transform.GetChild(2).gameObject;

        questUI.SetActive(false);
        dialogueBox.SetActive(false);

        thisNPC = RandomNPC();

        if (thisNPC != null)
        {
            GetData(thisNPC);

            currentStatus = Status.IDLE;
            idleChat.SetActive(false);

            float randomValue = Random.value;//rand chance to have quest
            if (randomValue <= 0.7)
            {
                //chances to receive quest
                isAvailableForQuest = true;
                path = 3;
                RandomQuest();

                Debug.Log("quest is available");
            }
            else
            {
                isAvailableForQuest = false;
                path = Random.Range(0, 2); //depends on the player's level later
            }
        }
    }

    private void Update()
    {
        if (!checkInRange) // if there is the player within the scene -> randomly pop up a random chat
        {
            if (timerText != null)
            {
                timerText.text = currentTime.ToString();
            }

            if (currentStatus == Status.IDLE)
            {
                if (currentTime <= popChatCooldown)
                {
                    currentTime += Time.deltaTime;
                }
                else if (currentTime >= popChatCooldown)
                {
                    StartCoroutine(WaitForTime(5));
                }
            }
            else
                StopAllCoroutines();

            questUI.SetActive(false);
            dialogueBox.SetActive(false);

            movement.enabled = true;
            playerStamina.enabled = true;
        }

        else
        {
            StopAllCoroutines();
            if (currentStatus == Status.IDLE) //not talking to anyone
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                    currentStatus = Status.TALKING;
                }
            }
            else
            {
                //if only when the path is 3 == quest available => able to show quest
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!interacting || hasAcceptedQuest)
                    {
                        dialogueBox.SetActive(false);
                        currentStatus = Status.IDLE;
                    }

                    else if (interacting)
                    {
                        if (!hasTakenQuest)
                        {
                            ShowQuest();
                            dialogueBox.SetActive(false);
                            hasTakenQuest = true;
                        }
                    }
                }
            }
        }

        if (currentStatus == Status.TALKING)
        {
            movement.enabled = false;
            playerStamina.enabled = false;

        }
        else if (currentStatus == Status.IDLE)
        {
            movement.enabled = true;
            playerStamina.enabled = true;
        }
    }

    public CreateNPC RandomNPC() //Random which NPC to spawn
    {
        int randomValue = Random.Range(0, allNPC.Count);
        return allNPC[randomValue];
    }

    public void GetData(CreateNPC npc) //Get Name for NPC
    {
        TextMeshPro text = nameText.GetComponent<TextMeshPro>();
        text.text = npc.NPCName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            checkInRange = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        checkInRange = false;
        currentStatus = Status.IDLE;
    }

    private void PopUpChat()
    {
        //talk for fun. increase interaction and maybe friendship for better quest reward
        float randomTalkChance = Random.value;
        //Debug.Log(randomTalkChance);

        if (randomTalkChance <= 0.5)
        {
            idleChat.SetActive(true);
            
            if (!isAvailableForQuest)
            {
                //not every npc hold quests

                switch (path) //keep random for now
                {
                    case 0:
                        chatText.text = "";
                        //nothing special, just random greetings and cozy conversation - spawn rate reduce as the player level up
                        break;

                    case 1:
                        chatText.text = "A treasure..."; //baiting people to talk, then give them ITEM
                                                         //"Found this under my bed this morning, I think you might need it!";
                                                         //randomize ITEM and give them to the player
                        break;

                    case 2:
                        chatText.text = "I heard that you are familiar with the Dark Woods..."; //indicating to eat berry for health
                                                                                                //Are you hungry? I heard that berries are very good for your health! //tips for survival within the darkwood
                                                                                                //Congrats (if obtained a new item, obtained a special item, first time clear,... - reward with 1 gold for talking)
                        break;
                }
            }
            else //quest is available
            {
                if (quest != null)
                {
                    if (quest.questItem == CreateQuest.QuestItem.Villagers)
                    {
                        //for urgent quest
                        chatText.text = "Please, help...";
                    }

                    else
                    {
                        int b = GetRandomValue();
                        switch (b)
                        {
                            case 0:
                                chatText.text = "Hero, can you please listen to this man's request?";
                                break;

                            case 1:
                                chatText.text = "I need your help!";
                                break;

                            case 2:
                                chatText.text = "A request for a deserved hero...";
                                break;
                        }
                    }
                }
                else
                {
                    Debug.Log("There is no assigned quest");
                }
            }
        }
    }

    public void Interact()
    {
        dialogueBox.SetActive(true);

        DialogueReceiver receiver = FindObjectOfType<DialogueReceiver>();
        receiver.speakerName.text = thisNPC.NPCName;

        if (!hasSpoken)
        {
            string text = CustomDialogue(path);
            receiver.diaText.text = text;

            if (path == 3)
            {
                interacting = true;
            }
            else
                interacting = false;

            hasSpoken = true;
        }
        else
        {
            if (hasAcceptedQuest)
            {
                string reply = "You have taken a quest from this NPC";
                receiver.diaText.text = reply;
            }
            else if (!interacting)
            {
                string reply = "You have talked to this NPC";
                receiver.diaText.text = reply;
            }
        }
    }

    public string CustomDialogue( int value)
    {
        switch (value)
        {  
            case 0:
                int randCasual = GetRandomValue();
                switch (randCasual)
                {
                    case 0:
                        return "Greetings. What a beautiful day this morning!";

                    case 1:
                        return "The weather today is great to hang out by the Square!";

                    case 2:
                        return "I bought some cookies from the Trader this morning. They look ... questioning, but taste great!"; //HAPPY COOKIES - gift 6 cookies for a girl in the dark wood
                }
                break;

            case 1:
                //int randItem= //AFTER INVENTORY

                int randGift = GetRandomValue();
                switch (randGift)
                {
                    case 0:
                        return "Found this under my bed this morning, I think you might need it!";

                    case 1:
                        return "Got this from a friend! Do not tell them I gave this to you though!";

                    case 2:
                        return "I cleaned my basement and found this... not sure how to use that to be honest";
                }

                break;

            case 2:
                int randTips = GetRandomValue();
                switch (randTips)
                {
                    case 0:
                        return "Are you hungry? I heard that berries are very good for your health!";

                    case 1:
                        return "Energy Drinks are pretty great for your stamina, just in case you need them, I think that the Trader sells them!";

                    case 2:
                        return "I heard that there is a mysterious Secret Trader in the wood! Spooky~ If you give him your coins he might trade some <color=yellow>Golds</color> for it!";
                }

                break;

            case 3:
                int randRequest = GetRandomValue();
                switch (randRequest)
                {
                    case 0:
                        return "Would you like to listen to my request?";

                    case 1:
                        return "I see my commission has reached your hand, would you like to accept it?";

                    case 2:
                        return "The way I see it, a hero comes to save the day!";
                }

                break;

            default:
                return "";
        }
        return "";

    }

    public void ShowQuest()
    {
        //animation of the dialoguebox

        //insert text
        questUI.SetActive(true);

        QuestLogic questBox = FindObjectOfType<QuestLogic>();

        questBox.questName.text = quest.questTitle;
        questBox.questDetails.text = quest.questDescription;

        string intro = FormattedIntro();
        questBox.questIntro.text = intro;

        //dialogueBox..text = quest.questDescription;
    }

    public string FormattedIntro()
    {

        int r = Random.Range(0, 3);

        switch (r)
        {
            case 0:
                return $"<color=blue>{thisNPC.NPCName}</color> has a request for you!";

            case 1:
                return $"<color=blue>{thisNPC.NPCName}</color> is seeking for your help...";

            case 2:
                return $"A new commission from <color=blue>{thisNPC.NPCName}</color> just arrived!";

        }

        return "";
    }

    public void RandomQuest()
    {
        //Debug.Log("receiving quest");
        int r = Random.Range(0, allQuest.Count);
        quest = allQuest[r];
    }

    public void AcceptQuest()
    {
        GameObject qmObject = GameObject.Find("IG_QUEST");
        QuestManager qm = qmObject.GetComponent<QuestManager>();

        if (qm.addedQuest.Count < qm.maxQuest)
        {
            hasAcceptedQuest = true;
            qmObject.SetActive(true);
            qm.addedQuest.Add(quest);
            qm.UpdateNewQuest();

            questUI.SetActive(false);
            currentStatus = Status.IDLE;
        }
        else
            Debug.Log("Cannot accept more quests");
    }

    public void DeclineQuest()
    {
        questUI.SetActive(false);
        dialogueBox.SetActive(true);

        DialogueReceiver dia = FindObjectOfType<DialogueReceiver>();
        dia.diaText.text = "Alright, I guess you do not have time for this. I am leaving";

        currentStatus = Status.IDLE;
        Destroy(this.gameObject,3f);
    }

    public int GetRandomValue()
    {
        return Random.Range(0, 2);
    }

    IEnumerator WaitForTime(float time)
    {
        currentTime = 0;
        PopUpChat();
        yield return new WaitForSeconds(time);
        idleChat.SetActive(false);
    }
}
