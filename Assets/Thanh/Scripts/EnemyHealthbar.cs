using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    public Health health;

    void Start()
    {
        //health = GetComponent<Health>();
    }
    public void UpdateHealthBar() //to get the value from any object, not restricting from only the player or enemy
    {

        slider.value = health.currentHealth;
        slider.maxValue = health.maxHealth;
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
