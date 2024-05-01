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

        // Stop the animation at the start
        animator.enabled = false;
    }

    //public void PlayAnimation()
    //{
    //    // Play the animation
    //    animator.enabled = true;
    //}
}
