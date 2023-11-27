using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyCharm : MonoBehaviour
{
    PlayerMovement pmScript;
    private bool isPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        pmScript = FindObjectOfType<PlayerMovement>();
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
