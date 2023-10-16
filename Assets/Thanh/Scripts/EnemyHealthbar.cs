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

    public void UpdateHealthBar(float maxValue, float currentValue) //to get the value from any object, not restricting from only the player or enemy
    {
        slider.value = currentValue / maxValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.position; //so that the healthbar wont rotate around the enemy
        transform.position = target.position + offset;
    }
}
