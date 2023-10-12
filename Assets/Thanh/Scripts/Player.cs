using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InputActionReference attack, pointer;
    private WeaponHolder weaponHolder;
    private Vector2 pointerInput;
    public Vector2 PointerInput => pointerInput;
    private void Awake()
    {
        weaponHolder = GetComponentInChildren<WeaponHolder>();
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
}
