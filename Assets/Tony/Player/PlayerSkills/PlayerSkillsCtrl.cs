using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsCtrl : MonoBehaviour
{

    public PlayerSkillsUI skillUI;

    public int peopleSkillPoint=0;
    public int brainPowerPoint =0;
    public int staminaPoint =0;
    public int charismaPoint=0;
    public int cookingSkillPoint=0;
    public string[] prestigeRank;
    public float socialScore=0; //can be negative

    #region UI
    public Zoomer Zoomer;
    public KeyCode Key;

    private void Update()
    {
        UpdateUI();
    }
    private void UpdateUI()
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
            }
        }

       
    }
    #endregion

    public virtual void IncreaseSkill()
    {
        

        //set points to increase XX amount...(can be set in other scripts)


    }


    //Increase skills function
    //Decrease skills function
}
