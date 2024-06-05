using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewSkillTree : MonoBehaviour
{
    [System.Serializable]
    public class Skill
    {
        public Button button;
        public bool isUnlocked = false;
        public bool isUpgraded = false;
    }

    public Skill skill1;
    public Skill[] skillsAfterSkill1;
    public Skill finalSkill;
    public DraftPM draftPMScript; // Reference to DraftPM script

    void Start()
    {
        skill1.button.interactable = skill1.isUnlocked;
        skill1.button.onClick.AddListener(() => UnlockSkillsAfterSkill1());

        foreach (var skill in skillsAfterSkill1)
        {
            skill.button.interactable = skill.isUnlocked;
            skill.button.onClick.AddListener(() => UpgradeSkill(skill));
        }

        finalSkill.button.interactable = finalSkill.isUnlocked;
    }

    void UnlockSkillsAfterSkill1()
    {
        skill1.isUpgraded = true;
        draftPMScript.EnableDash(); // Enable dash ability when the first skill is upgraded

        foreach (var skill in skillsAfterSkill1)
        {
            skill.isUnlocked = true;
            skill.button.interactable = true;
        }
    }

    void UpgradeSkill(Skill skill)
    {
        skill.isUpgraded = true;
        skill.button.interactable = false; // Optionally disable button after upgrading

        CheckFinalSkillUnlock();
    }

    void CheckFinalSkillUnlock()
    {
        foreach (var skill in skillsAfterSkill1)
        {
            if (!skill.isUpgraded)
                return;
        }

        finalSkill.isUnlocked = true;
        finalSkill.button.interactable = true;
    }
}
