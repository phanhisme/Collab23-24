using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPointer : MonoBehaviour
{
    [SerializeField]
    private InputActionReference attack, pointer;
    private PlayerWeaponHolder playerWeaponHolder;
    private Vector2 pointerInput;
    GameObject shield;
    public Vector2 PointerInput => pointerInput;
    public bool shielded;
    public bool boostAttackSpeed = false;
    public bool startStackingGM;
    public bool needleStrike;
    public bool thornArmorActive;

    private void Start()
    {
        shield = transform.Find("Shield").gameObject;
        DeActivateShield();
        //playerHealth = 70;
        playerWeaponHolder = GetComponentInChildren<PlayerWeaponHolder>();
    }
    private void Awake()
    {
        
    }
    private void Update()
    {
        pointerInput = GetPointerInput();
        //Debug.Log(pointerInput);
        playerWeaponHolder.PointerPosition = pointerInput;
    }
    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext context)
    {
        playerWeaponHolder.Attack();
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointer.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    public void ActivateShield()
    {
        shield.SetActive(true);
        shielded = true;
    }
    public void DeActivateShield()
    {
        shield.SetActive(false);
        shielded = false;
    }
    public bool HasShield()
    {
        return shield.activeSelf;
    }

    public void ActivateTitanGlove()
    {
        boostAttackSpeed = true;
        //Debug.Log("b");
    }
    public void DeActivateTitanGlove()
    {
        boostAttackSpeed = false;
    }
    public void ActivateGM()
    {
        startStackingGM = true;
    }
    public void ActivateNS()
    {
        needleStrike = true;
    }
    public void ActivateTA()
    {
        thornArmorActive = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpScript powerUp = collision.GetComponent<PowerUpScript>();
        if(powerUp)
        {
            if(powerUp.activeShield)
            {
                ActivateShield();
            }
            if (powerUp.activeTitanGlove)
            {
                ActivateTitanGlove();
            }
            if(powerUp.activeGoldenMoment)
            {
                ActivateGM();
            }
            if(powerUp.activeNeedleStrike)
            {
                ActivateNS();
            }
            if(powerUp.activeThornArmor)
            {
                ActivateTA();
            }
            Destroy(powerUp.gameObject);
        }
    }
}
