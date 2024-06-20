using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadOutActivationUI : MonoBehaviour
{
    public ActivationSO activeSO;
    public TextMeshProUGUI activeName; 
    public Image activeIcon;

    public void Start()
    {
        activeName.text = activeSO.activationName;
        activeIcon.sprite = activeSO.activationIcon;
    }

    public void HoverOn()
    {
        LoadOutManager loadOutManager = FindObjectOfType<LoadOutManager>();
        loadOutManager.activeDes.text = activeSO.activationDescription;
    }

    public void SetChosen()
    {
        LoadOutManager loadOutManager = FindObjectOfType<LoadOutManager>();
        loadOutManager.activeSO = activeSO;
        loadOutManager.activeDes.text = loadOutManager.activeSO.activationDescription;
    }
}
