using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    public float horizontalMove;
    public float verticalMove;
    public float speed = 10.0f;
    //player movement control

    //destroy duplicate player when load scenes
    public static PlayerControls playerInstance;

    

    private void Start()
    {
        //create a spawn point code
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }




    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0, 0, verticalMove);
            transform.Translate(horizontalMove, 0, 0);
        }


    }


   
}
