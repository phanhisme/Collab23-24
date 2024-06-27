using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadOutManager : MonoBehaviour
{
    //CHOOSE
    public TextMeshProUGUI weaponDes;
    public GameObject changeButton;

    public Status status;
    public enum Status { CHOOSING, IDLE};

    //SETUP
    public WeaponSO so;
    public TextMeshProUGUI chosenName;
    public Image selectedIcon;

    //Activation
    public ActivationSO activeSO;
    public TextMeshProUGUI chosenActiveName;
    public TextMeshProUGUI activeDes;
    public Image chosenActiveIcon;

    void Start()
    {
        status = Status.CHOOSING;
    }

    public void SetUp()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (status == Status.IDLE)
        {
            changeButton.SetActive(true);
        }
        else if (status == Status.CHOOSING)
        {
            changeButton.SetActive(false);
        }

        if (so == null)
        {
            selectedIcon.gameObject.SetActive(false);
            chosenName.text = "Choosing...";
        }
        else
        {
            selectedIcon.gameObject.SetActive(true);
            selectedIcon.sprite = so.weaponIcon;
            chosenName.text = so.weaponName;
        }

        if (activeSO == null)
        {
            chosenActiveIcon.gameObject.SetActive(false);
            chosenActiveName.text = "Choosing...";
        }
        else
        {
            chosenActiveIcon.gameObject.SetActive(true);
            chosenActiveIcon.sprite = activeSO.activationIcon;
            chosenActiveName.text = activeSO.activationName;
        }
    }
}
