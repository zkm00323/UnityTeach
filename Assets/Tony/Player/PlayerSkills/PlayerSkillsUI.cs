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

    #region UI
    public Zoomer skillZoomer;
    public KeyCode Key;

    /*private void UpdateUI()
    {
        if (Input.GetKeyDown(Key))
        {
            if (Zoomer.gameObject.activeSelf)
            {
                Zoomer.ZoomOut();
                if (ItemUICtrl.Selecting != null)
                    ItemUICtrl.Selecting.UnSelect();
            }
            else
            {
                //skillUI.SetUp(new WorkData(Info, 0, 0));
                Zoomer.ZoomIn();
                SetUp();
            }
        }


    }*/
    #endregion
    // Update is called once per frame

    public void SetUp() {
        playerSkills = FindObjectOfType<PlayerSkillsCtrl>();
        peopleSkillPoint.text = "People Skill: " + PlayerData.Skills.Instance.peopleSkillPoint.ToString();
        brainPowerPoint.text = "Brain power: "+ PlayerData.Skills.Instance.brainPowerPoint.ToString();
        staminaPoint.text = "Stamina: "+PlayerData.Skills.Instance.staminaPoint.ToString();
        charismaPoint.text = "Charisma: "+ PlayerData.Skills.Instance.charismaPoint.ToString();
        if(cookingSkillPoint!=null)cookingSkillPoint.text = "Cooking: "+ PlayerData.Skills.Instance.cookingSkillPoint.ToString();
        if(socialScore!=null)socialScore.text = "Social Rank Score: "+ PlayerData.Skills.Instance.socialScore.ToString();

        skillZoomer.ZoomIn();
    }

   
}
