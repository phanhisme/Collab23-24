using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public GameObject navObject;

    public GameObject loadOutPanel;
    public GameObject questPanel;
    public GameObject inventoryPanel;

    public GameObject loadOutText;
    public GameObject questText;
    public GameObject inventoryText;

    public void OpenLoadout()
    {
        loadOutPanel.SetActive(true);
    }

    public void OpenQuest()
    {
        questPanel.SetActive(true);
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(false);
    }

    public void CloseLoadout()
    {
        loadOutPanel.SetActive(false);
    }
    public void CloseQuest()
    {
        questPanel.SetActive(false);
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    public void HoverLoadOut()
    {
        loadOutText.SetActive(true);
    }

    public void HoverQuest()
    {
        questText.SetActive(true);
    }

    public void HoverInventory()
    {
        inventoryText.SetActive(true);
    }

    public void HoverOff()
    {
        loadOutText.SetActive(false);
        questText.SetActive(false);
        inventoryText.SetActive(false);
    }

}
