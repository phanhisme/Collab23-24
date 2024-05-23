using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerSk : MonoBehaviour
{
    private PlayerSkill playerSkills;
    private void Awake()
    {
        playerSkills = new PlayerSkill();
        playerSkills.OnSkillUnlocked += PlayerSkill_OnSkillUnlocked;
    }
    private void PlayerSkill_OnSkillUnlocked(object sender, PlayerSkill.OnSkillUnlockedEventArgs e)
    {
        switch (e.skillType)
        {
            case PlayerSkill.SkillType.Dash:
                break;
        }
    }
    public PlayerSkill GetPlayerSkill()
    {
        return playerSkills;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
