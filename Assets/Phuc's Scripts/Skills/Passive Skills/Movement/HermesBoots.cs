using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermesBoots : MonoBehaviour
{

    PlayerMovement playermovementScript;
    public float currentSpeed;
    public bool HermesBootsPickedUp;
    [SerializeField]
    private float boostSpeed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        playermovementScript = FindObjectOfType<PlayerMovement>();
        HermesBootsPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        PickUpBoots();
    }

    void PickUpBoots()
    {
        currentSpeed = playermovementScript.moveSpeed += boostSpeed;
        HermesBootsPickedUp = true;
        Debug.Log(playermovementScript.moveSpeed);
    }
}
