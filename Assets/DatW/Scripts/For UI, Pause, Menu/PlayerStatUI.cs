using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatUI : MonoBehaviour
{
    public RectTransform LoadoutImg; 
    public RectTransform SkillTreeImg;
    
    public Button SkillTreeButton; 
    public Button LoadoutButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the first button click event
        LoadoutButton.onClick.AddListener(BringSecondImageToTop);
        // Add a listener to the second button click event
        SkillTreeButton.onClick.AddListener(BringFirstImageToTop);
    }
    void BringSecondImageToTop()
    {
        // Move the second image to the top
        SkillTreeImg.SetSiblingIndex(LoadoutImg.GetSiblingIndex() + 1);
        
    }

    void BringFirstImageToTop()
    {
        // Move the first image to the top
        LoadoutImg.SetSiblingIndex(SkillTreeImg.GetSiblingIndex() + 1);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadOut()
    {

    }
    public void SkillTree()
    {

    }
}
