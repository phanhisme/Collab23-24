using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    //animation
    //pattern
    //overlap
    public float range;
    public float power;
    public float affectedSpeed;
    public float weight;
    public float delay;
    public virtual void Attack(Animator animator)
    {

    }
}
