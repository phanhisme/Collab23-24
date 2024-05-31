using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpear : WeaponBase
{
    public int maxCombo = 3;
    public int currentCombo = 0;
    //float elaspetime
    public override void Attack()
    {
        base.Attack(); 
        currentCombo++;
        //animator.GetCurrentAnimatorStateInfo(0).Length;
        //elaspeTime
    }
}
