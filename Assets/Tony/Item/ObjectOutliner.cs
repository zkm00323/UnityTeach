using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutliner : MonoBehaviour
{
    public GameObject player;
    public Shader shader1;
    public Shader shader2;
    public float outlineSize = 0.01f;
    public float distanceToAct = 2;
    public Color outlineColor = Color.black;
    private bool alreadyNear = false;


    public Material material;
    public Material Outlined;


    void Start()
    {
        shader1 = Shader.Find("Outline");
        shader2 = Shader.Find("Outlined/Silhouetted Diffuse");

    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance <= distanceToAct)
        {
            if (!alreadyNear)
            {
                alreadyNear = true;
                //gameObject.GetComponent<Renderer>().material
            }
        }
    }

}
