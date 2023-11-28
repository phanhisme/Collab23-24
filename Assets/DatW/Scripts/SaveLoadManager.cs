using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    // The player controller script attached to your player object
    public Playermm playerController;

    // Attach your UI buttons to these fields in the Inspector
    public Button saveButton;
    public Button loadButton;

    // Start is called before the first frame update
    void Start()
    {
        // Attach the Save and Load methods to the button click events
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
    }

    // Save the death count to PlayerPrefs
    private void Save()
    {
        playerController.SaveDeathCount();
    }

    // Load the death count from PlayerPrefs
    private void Load()
    {
        playerController.LoadDeathCount();
        playerController.UpdateDeathCountText(); // Update the UI text with the loaded death count
    }
}

