using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    
    [SerializeField]
    private InputActionReference attack, pointerPosition;
    private Vector2 pointerInput;
    private WeaponHolder weaponHolder;
    

    private void Awake()
    {
        weaponHolder = GetComponentInChildren<WeaponHolder>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponHolder.PointerPosition = pointerInput;
    }

    private void PerformAttack(InputAction.CallbackContext context)
    {
        weaponHolder.Attack();
    }

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }
    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    
}
