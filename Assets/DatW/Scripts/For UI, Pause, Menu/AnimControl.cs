using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string chooseWeapAnim = "WeapChooseAnim";
    [SerializeField] private string closeWeapAnim = "WeapChooseCloseAnim";
    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Stop all animations at the start
        animator.SetBool("WeapChooseAnim", false);
        animator.SetBool("WeapChooseCloseAnim", false);
    }

    public void PlayAnimation1()
    {
        animator.Play(chooseWeapAnim,0, 0.0f);
    }

    public void PlayAnimation2()
    {
        
        animator.Play(closeWeapAnim, 0, 0.0f);
    }
}
