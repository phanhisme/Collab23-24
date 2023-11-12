using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float shieldTimer = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
    public void Timer()
    {
        if (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;
            Debug.Log("a");

        }
        if (shieldTimer < 0)
        {
            
            
            Debug.Log(shieldTimer);
            shieldTimer = 2;
        }
        int minutes = Mathf.FloorToInt(shieldTimer / 60);
        int seconds = Mathf.FloorToInt(shieldTimer % 60);
    }
}
