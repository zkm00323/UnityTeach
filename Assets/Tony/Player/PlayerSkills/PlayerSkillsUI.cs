using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSkillsUI : MonoBehaviour
{
    private PlayerSkillsCtrl playerSkills;

    [SerializeField] private TMP_Text peopleSkillPoint;
    [SerializeField] private TMP_Text brainPowerPoint;
    [SerializeField] private TMP_Text staminaPoint;
    [SerializeField] private TMP_Text charismaPoint;
    [SerializeField] private TMP_Text cookingSkillPoint;
    [SerializeField] private TMP_Text prestigeRank;
    [SerializeField] private TMP_Text socialScore;

    //private PlayerSkillsCtrl playerSkills;

   


    void Start() //or awake?
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        SetUp();
    }
    public void SetUp()
    {
        playerSkills = FindObjectOfType<PlayerSkillsCtrl>();
        peopleSkillPoint.text = "People Skill: " + playerSkills.peopleSkillPoint.ToString();
        brainPowerPoint.text = "Brain power: "+ playerSkills.brainPowerPoint.ToString();
        staminaPoint.text = "Stamina: "+playerSkills.staminaPoint.ToString();
        charismaPoint.text = "Charisma: "+playerSkills.charismaPoint.ToString();
        if(cookingSkillPoint!=null)cookingSkillPoint.text = "Cooking: "+playerSkills.cookingSkillPoint.ToString();
        if(socialScore!=null)socialScore.text = "Social Rank Score: "+playerSkills.socialScore.ToString();

    }

   
}
