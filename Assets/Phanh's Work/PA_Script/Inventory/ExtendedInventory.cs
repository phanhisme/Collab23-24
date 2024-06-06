using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedInventory : MonoBehaviour
{
    public int stageCoin;
    public int Gold;

    public List<Items> items = new List<Items>();

    public List<WeaponSO> allWeapons = new List<WeaponSO>();
    public List<WeaponSO> availableWeapons = new List<WeaponSO>();

    public Activation chosenActivation;
    public enum Activation
    {
        Invisible,
        CursedBlade,
        HealthyHabit,
        GoldenMoment
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
