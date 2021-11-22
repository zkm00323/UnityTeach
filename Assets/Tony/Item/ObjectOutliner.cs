using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutliner : MonoBehaviour
{
    private GameObject player;

    public float defaultSize;
    public float outlineSize;
    public float distanceToAct = 2;
    //public Color outlineColor = Color.black;
    private bool alreadyNear = false;


    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance <= distanceToAct)
        {
            if (!alreadyNear)
            {
                alreadyNear = true;
                gameObject.GetComponent<MeshRenderer>().material.SetFloat("_OutlineWidth", outlineSize);
            }
            
        }
        else
        {
            alreadyNear = false;
            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_OutlineWidth", defaultSize);
        }
    }

}
