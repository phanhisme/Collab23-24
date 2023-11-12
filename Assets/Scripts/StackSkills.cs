using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSkills : MonoBehaviour
{
    [Header("Invisibility Related")]
    PlayerMovement pmScript;
    Invisibility invisScript;

    [SerializeField] private int invisMaxStack = 2;
    [SerializeField] private float invisStackCooldown = 8;
    private bool ifThereIsStack, InvisButtonPress, IsUsingInvis;
    // Start is called before the first frame update
    void Start()
    {
        pmScript = FindObjectOfType<PlayerMovement>();
        invisScript = FindObjectOfType<Invisibility>();
        //---- INVISIBILITY RELATED ----
        InvisButtonPress = invisScript.canButtonPressed;
        IsUsingInvis = invisScript.isActivated;
    }

    // Update is called once per frame
    void Update()
    {
        StacksCooldown();
        InvisStackCooldown();
    }
    void StacksCooldown()
    {
        if(IsUsingInvis && InvisButtonPress)
        {
            invisMaxStack = invisMaxStack - 1;
            if(invisMaxStack <= 0)
            {
                ifThereIsStack = false;
            }
        }
    }
    void InvisStackCooldown()
    {
        if(!ifThereIsStack)
        {
            invisStackCooldown -= Time.deltaTime;

        }
        if(invisStackCooldown == 0)
        {
            invisMaxStack = 2;
            ifThereIsStack = true;
        }
    }
    IEnumerator StartInvisCooldown()
    {


        yield return new WaitForSeconds(8f);
    }
}
