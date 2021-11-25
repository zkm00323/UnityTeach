using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutliner : MonoBehaviour //attach to object you want to highlight
{
    private GameObject player;

    //public float defaultSize;
   
    public float distanceToAct = 2;
    //public Color outlineColor = Color.black;
    private bool alreadyNear = false;
    public float defaultWidth;
    public float outlineSize;
    



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.GetComponent<OutlineAddOn>().OutlineWidth=0;
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance <= distanceToAct)
        {
            if (!alreadyNear)
            {
                alreadyNear = true;
                //gameObject.GetComponent<MeshRenderer>().material.SetFloat("_OutlineWidth", outlineSize);
                gameObject.GetComponent<OutlineAddOn>().OutlineWidth = outlineSize;
            }
            
        }
        else
        {
            alreadyNear = false;
            gameObject.GetComponent<OutlineAddOn>().OutlineWidth = 0;
        }
    }

}
