using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
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
        // Stop other animations and play Animation1
        animator.SetBool("WeapChooseAnim", true);
        animator.SetBool("WeapChooseCloseAnim", false);
    }

    public void PlayAnimation2()
    {
        // Stop other animations and play Animation2
        animator.SetBool("WeapChooseAnim", false);
        animator.SetBool("WeapChooseCloseAnim", true);
    }
}
