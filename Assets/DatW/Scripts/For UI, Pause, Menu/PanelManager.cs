using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    //public GameObject panel; // Reference to the panel with 3 image slots

    //// Method to show or hide the panel
    //public void TogglePanel()
    //{
    //    panel.SetActive(!panel.activeSelf);
    //}
    public GameObject saveSlotsPanel; // The panel with three image slots
    public GameObject overlayPanel; // The transparent overlay panel

    void Start()
    {
        // Initially hide the overlay panel
        overlayPanel.SetActive(false);
    }

    // Method to show the save slots panel
    public void ShowSaveSlotsPanel()
    {
        saveSlotsPanel.SetActive(true);
        overlayPanel.SetActive(true); // Show the overlay panel
    }

    // Method to hide the save slots panel
    public void HideSaveSlotsPanel()
    {
        saveSlotsPanel.SetActive(false);
        overlayPanel.SetActive(false); // Hide the overlay panel
    }

    // Called when the overlay panel is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        HideSaveSlotsPanel(); // Hide the save slots panel
    }

    public void StartGame()
    {
        SceneManager.LoadScene(12);
    }

    public void Exit()
    {
        Debug.Log("quitting");
        Application.Quit();
    }
}
