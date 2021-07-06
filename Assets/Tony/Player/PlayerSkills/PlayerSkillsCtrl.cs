using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsCtrl : MonoBehaviour
{

    public PlayerSkillsUI skillUI;

   

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
