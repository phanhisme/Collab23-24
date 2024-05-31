using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataSO : ScriptableObject
{
    public float range;
    public float power;
    public float affectedSpeed;
    public float weight;
    public float delay;
    public bool attackBlocked;
    public float attackSpeedBoost;
}
