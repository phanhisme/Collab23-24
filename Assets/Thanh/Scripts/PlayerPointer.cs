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
    private WeaponHolder weaponHolder;
    private Vector2 pointerInput;
    GameObject shield;
    //GameObject titanGlove;
    public float shieldHealth = 2;
    //public float shieldTimer = 2;
    public Vector2 PointerInput => pointerInput;
    public bool shielded;
    public bool boostAttackSpeed = false;
    private void Start()
    {
        shield = transform.Find("Shield").gameObject;
        //titanGlove = transform.Find("")
        DeActivateShield();
        Debug.Log(shieldHealth);
        //playerHealth = 70;
        weaponHolder = GetComponentInChildren<WeaponHolder>();
    }
    private void Awake()
    {
        
    }
    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponHolder.PointerPosition = pointerInput;
    }
    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext context)
    {
        weaponHolder.Attack();
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
            Destroy(powerUp.gameObject);
        }
    }
}
