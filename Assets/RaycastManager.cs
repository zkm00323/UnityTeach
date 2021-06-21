using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string foodTag = "Food";
    [SerializeField] private string hygieneTag = "HygieneProduct";
    [SerializeField] private string jobTag = "Job";

    public FoodObject food;
    //Raycast manager
    void Update()
    {

        Raycast();

    }

    void Raycast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(foodTag) || selection.CompareTag(hygieneTag) || selection.CompareTag(jobTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
            }


        }
    }
}
