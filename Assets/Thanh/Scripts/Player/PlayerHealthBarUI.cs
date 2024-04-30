using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private PlayerHealth playerHealth;

    void Start()
    {
        //playerHealth = GetComponent<PlayerHealth>();
    }
    public void UpdateHealthBar() //to get the value from any object, not restricting from only the player or enemy
    {

        slider.value = playerHealth.currentHealth;
        slider.maxValue = playerHealth.maxHealth;
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.position; //so that the healthbar wont rotate around the enemy
        transform.position = target.position + offset;
        transform.rotation = camera.transform.rotation;
        UpdateHealthBar();
    }
}
