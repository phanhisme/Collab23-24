using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class UI_SkillTree : MonoBehaviour
{
    private PlayerSkill playerSkill;
    private void Awake()
    {
        transform.Find("skillbt").GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkill.UnlockSkill(PlayerSkill.SkillType.Dash);
            Debug.Log("Click");
        };
    }

    public void SetPlayerSkills(PlayerSkill playerSkill)
    {
        this.playerSkill = playerSkill;
    }
}
