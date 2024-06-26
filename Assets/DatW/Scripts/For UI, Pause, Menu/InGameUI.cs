using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject QuestMenu;
    // Reference to the Animator components
    public Animator animator;
  

    // The names of the animations to be triggered
    public string animationName1;
    public string animationName2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //someUIButtonReference.onClick.AddListener(SomeFunction1);
        //someUIButtonReference.onClick.AddListener(SomeFunction2);
    }
    public void Quest()
    {
        QuestMenu.SetActive(true);
    }
    public void Inventory()
    {


    }
    public void LoadOutIG()
    {

    }
    public void PlayAnimations()
    {
        if (animator != null)
        {
            animator.Play(animationName1);
            animator.Play(animationName2);
        }
    }
}
