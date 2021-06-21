using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClothesHygineFurnitures : MonoBehaviour
{
    public FoodObject food1;
    public FurnitureObject furniture;
    public HygieneObject hygieneProduct;
    // Start is called before the first frame update

    //Call Raycast function
    //RaycastManager ray;

    private void Start()
    {
        Debug.Log(food1.FoodName);
    }

    private void Update()
    {
        RaycastHit hit; //reference type variable/ variable that holds reference to object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (gameObject.tag == "Food") //(food1)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("clicked on Food name " + gameObject.name);
                    food1.Eat();
                    Destroy(gameObject);
                }
            }

        }

        else if (gameObject.tag == "HygieneProduct")
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("clicked on Hygiene" + gameObject.name);
                    hygieneProduct.Clean();
                    
                }
            }

        }

        else if (gameObject.tag == "Job")
        {
            //Debug.Log("job object doing raycast");
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("job object raycast hits something");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("clicked on job" + gameObject.name);
                    hit.transform.gameObject.GetComponent<WorkMono>().ShowPanel();
                    

                }
            }

        }




        //make this script common to all items

    }


    
}
