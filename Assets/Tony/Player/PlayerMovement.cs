using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour{
    public static PlayerMovement Player;
    
    [SerializeField]
    public float _moveSpeed = 5f;
    [SerializeField]
    private float _gravity = 9.81f;
    public float rotationSpeed;

    private CharacterController controller;
    private Animator animator; //for later animation use
    // Start is called before the first frame update

    

    private void Awake(){
        Player = this;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoves();
        PlayerData.Instance.Update();
        handleAnimation();
        

    }
    private void playerMoves()
    {
      



        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction.Normalize();

        direction.y -= _gravity;

        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", false);
        }

        

        controller.Move(direction * Time.deltaTime * _moveSpeed); //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high
        if (direction!= Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        /*if (isMovementPressed)
        {
            animator.SetBool("isWalking", true);
        }*/

    }

    public void MoveTo(Vector3 targetPoint) //simply move to a point
    {
        Vector3 moveVector = targetPoint - Player.transform.position;
        controller.Move(moveVector);

    }
    
}
