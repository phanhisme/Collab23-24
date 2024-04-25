using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playermm : MonoBehaviour
{
    public float speed = 5f;
    public TextMeshProUGUI deathCountText;
    private string deathCountKey = "DeathCount";
    private int deathCount = 0;

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            Die(); 
        }
    }
    public void Die()
    {
        deathCount++;
        Debug.Log(deathCount);
        UpdateDeathCountText(); 

        
    }
    public void UpdateDeathCountText()
    {
        if (deathCountText != null)
        {
            deathCountText.text = "Deaths: " + deathCount.ToString();
        }
    }
    // Save death count to PlayerPrefs
    public void SaveDeathCount()
    {
        PlayerPrefs.SetInt(deathCountKey, deathCount);
        PlayerPrefs.Save();
    }

    // Load death count from PlayerPrefs
    public void LoadDeathCount()
    {
        deathCount = PlayerPrefs.GetInt(deathCountKey, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadDeathCount(); // Load the death count when the game starts
        UpdateDeathCountText(); // Update the UI text with the loaded death count
    }
}
