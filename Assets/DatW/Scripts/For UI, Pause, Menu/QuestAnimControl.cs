using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAnimControl : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string chooseIG = "IGlarv";
    [SerializeField] private string closeIG = "IGla";
    public bool isOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseChooseIG()
    {
        if (isOn == false)
        {
            OpenIG();

        }
        else
        {
            CloseIG();
        }
    }
    public void CloseIG()
    {
        
        if (isOn == true)
        {
            animator.Play(closeIG, 0, 0.0f);

        }
        isOn = false;
    }

    public void OpenIG()
    {
       
        if (isOn == false)
        {
            animator.Play(chooseIG, 0, 0.0f);
        }
        isOn = true;
    }
}
