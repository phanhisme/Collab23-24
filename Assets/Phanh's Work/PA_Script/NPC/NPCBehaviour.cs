using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCBehaviour : MonoBehaviour
{
    public Collider2D col;
    private bool hasSpoken = false; //has spoken in that day
    private bool hasTakenQuest = false; //ask if the player has finish the quest if this is true
    private bool checkInRange = false;
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
    
    private void Start()
    {
        currentStatus = Status.IDLE;
        idleChat.SetActive(false);

        float randomValue = Random.value;
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

    private void Update()
    {
        if (!checkInRange) // if there is the player within the scene -> randomly pop up a random chat
        {
            timerText.text = currentTime.ToString();

            if(currentStatus == Status.IDLE)
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
        }

        else
        {
            if (currentStatus == Status.IDLE) //not talking to anyone
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Interact();
                    currentStatus = Status.TALKING;
                }
            }
        }

        if (interacting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowQuest();
            }
        }

        if (currentStatus == Status.TALKING)
        {
            //LOCK INTERACTION
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            DashStamina playerStamina = player.GetComponent<DashStamina>();

            movement.enabled = false;
            playerStamina.enabled = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("escaping");
                currentStatus = Status.IDLE;
                movement.enabled = true;
                playerStamina.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
        Debug.Log(randomTalkChance);

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
        DialogueReceiver receiver = FindObjectOfType<DialogueReceiver>();
        receiver.speakerName.text = thisNPC.NPCName;

        switch (path)
        {
            case 0:
                int randCasual = GetRandomValue();
                switch (randCasual)
                {
                    case 0:
                        receiver.diaText.text = "Greetings. What a beautiful day this morning!";
                        break;

                    case 1:
                        receiver.diaText.text = "The weather today is great to hang out by the Square!";
                        break;

                    case 2:
                        receiver.diaText.text = "I bought some cookies from the Trader this morning. They look ... questioning, but taste great!"; //HAPPY COOKIES - gift 6 cookies for a girl in the dark wood
                                                                                                                                                   //traders sell 2 per day - 2 golds each
                        break;
                }
                break;

            case 1:
                //int randItem= //AFTER INVENTORY

                int randGift = GetRandomValue();
                switch (randGift)
                {
                    case 0:
                        receiver.diaText.text = "Found this under my bed this morning, I think you might need it!";
                        break;

                    case 1:
                        receiver.diaText.text = "I just ";
                        break;

                    case 2:
                        receiver.diaText.text = "Found this under my bed this morning, I think you might need it!";
                        break;
                }

                break;

            case 2:
                int randTips = GetRandomValue();
                switch (randTips)
                {
                    case 0:
                        receiver.diaText.text = "Are you hungry? I heard that berries are very good for your health!";
                        break;

                    case 1:
                        receiver.diaText.text = "Energy Drinks are pretty great for your stamina, just in case you need them, I think that the Trader sells them!";
                        break;

                    case 2:
                        receiver.diaText.text = "I heard that there is a mysterious Secret Trader in the wood! Spooky~ If you give him your coins he might trade some <color=yellow>Golds</color> for it!";
                        break;
                }

                break;

            case 3:
                int randRequest = GetRandomValue();
                switch (randRequest)
                {
                    case 0:
                        receiver.diaText.text = "Would you like to listen to my request?";
                        interacting = true;
                        break;

                    case 1:
                        receiver.diaText.text = "I see my commission has reached your hand, would you like to accept it?";
                        break;

                    case 2:
                        break;
                }
                
                break;
        }
    }

    public void ShowQuest()
    {
        //animation of the dialoguebox

        //insert text
        QuestLogic questBox = FindObjectOfType<QuestLogic>();
        questBox.chosenNPC = thisNPC;

        questBox.questName.text = quest.questTitle;
        questBox.questDetails.text = quest.questDescription;
        questBox.questIntro.text = questBox.FormattedIntro();

        //dialogueBox..text = quest.questDescription;
    }

    public void RandomQuest()
    {
        Debug.Log("receiving quest");
        int r = Random.Range(0, allQuest.Count);
        quest = allQuest[r];
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
