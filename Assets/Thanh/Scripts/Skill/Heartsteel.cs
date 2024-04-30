using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartsteel : MonoBehaviour
{
    public float shieldHeart = 2;
    public bool hasHeartSteel;
    PlayerPointer playerPointer;
    // Start is called before the first frame update
    void Start()
    {
        playerPointer = FindObjectOfType<PlayerPointer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForHeartsteel();
    }

    public void checkForHeartsteel()
    {
        if (playerPointer.heartsteelActive == true)
        {
            hasHeartSteel = true;
        }
    }
    public void DeactivateHeartsteel()
    {
        if (shieldHeart == 0)
        {
            hasHeartSteel = false;
            playerPointer.DeActivateHeartsteel();
        }
    }
}
