using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCBehaviour : MonoBehaviour
{
    public Collider2D col;
    private bool hasSpoken = false; //has spoken in that day
    private bool hasTakenQuest = false; //ask if the player has finish the quest if this is true

    public CreateNPC thisNPC; //npc scriptable - we can add NPC trait - to randomize what they might say from different traits

    public bool isAvailableForQuest = false; 
    public CreateQuest quest;

    public GameObject idleChat;
    public TextMeshPro chatText;

    private GameObject player;

    public TextMeshProUGUI timerText;
    public float popChatCooldown = 10.0f;
    public float currentTime = 0f;
    
    private void Start()
    {
        idleChat.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            timerText.text = currentTime.ToString();
            
            if (currentTime <= popChatCooldown)
            {
                currentTime += Time.deltaTime;
            }
            else if (currentTime >= popChatCooldown)
            {
                currentTime = 0;
                StartCoroutine(WaitForTime(2));
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void PopUpChat()
    {
        //talk for fun. increase interaction and maybe friendship for better quest reward
        float randomTalkChance = Random.value;
        Debug.Log(randomTalkChance);

        if (randomTalkChance <= 0.7)
        {
            idleChat.SetActive(true);
            
            if (!isAvailableForQuest)
            {
                //not every npc hold quests (20% only)
                int a = GetRandomValue();
                switch (a)
                {
                    case 0:
                        chatText.text = "Greetings.What a beautiful day this morning!";
                        //nothing special, just random greetings and cozy conversation - spawn rate reduce as the player level up
                        RandomCasualDialogue();
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
                    int b = 1;
                    switch (1)
                    {
                        case 0:
                            chatText.text = "Hero, can you please listen to this man's request?";
                            break;

                        case 1:
                            chatText.text = "I need your help!";
                            break;

                        case 2:
                            chatText.text = ""; //to be honest this is a bad design, i need to make this as muted as possible
                            break;
                    }
                }
                else
                {
                    Debug.Log("There is no assigned quest");
                }

            }

        }

        
    }

    public void RandomCasualDialogue()
    {

    }

    public void Interact()
    {

    }

    public int GetRandomValue()
    {
        return Random.Range(0, 2);
    }

    IEnumerator WaitForTime(float time)
    {
        
        PopUpChat();
        yield return new WaitForSeconds(time);
        idleChat.SetActive(false);
    }

}
