using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    public Image heal1;
    public float cd1 = 30f;
    bool isCD = false;
    public KeyCode ab1;
    //public Player player;
    public PlayerHealth playerHealth;
    public int healAmount;

    private void Awake()
    {
        //player = GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        heal1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Healing();  
    }

    void Healing()
    {
        if(Input.GetKey(ab1) && isCD == false)
        {
            isCD = true;
            heal1.fillAmount = 1;
            playerHealth.currentHealth = playerHealth.currentHealth + healAmount;
            //player.playerHealth = player.playerHealth + healAmount;
            Debug.Log(playerHealth.currentHealth);

        }
        if(isCD)
        {
            heal1.fillAmount -= 1 / cd1 * Time.deltaTime; 
            if(heal1.fillAmount <= 0 )
            {
                heal1.fillAmount = 0;
                isCD = false;
            }
        }
    }
}
