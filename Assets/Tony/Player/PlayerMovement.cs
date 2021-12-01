﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour{
    public static PlayerMovement Player;

    [SerializeField]
    public float walkSpeed;
    [SerializeField]
    public float runSpeed;
    [SerializeField]
    private float _gravity = 9.81f;
    public float rotationSpeed;

    private CharacterController controller;
    private Animator animator; //for later animation use
                               // Start is called before the first frame update

    private bool arrowsKeyPressed; //if any of the arrows keys are pressed
    
   

    enum MotionState { 
        Idle,
        Walking,
        Running
    }

   

    private MotionState mState = MotionState.Idle;
    private float lastUnpressed;
    private float pressSpan = 1;
    private bool hold;

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
        ArrowsKeyPressed();

        playerMoves();
        PlayerData.Instance.Update();
        handleAnimation();
        

    }


    void transitState(MotionState state) {
        if (mState == state)
            return;

        mState = state;
        Debug.Log($"State transite to {mState}");
        switch (state)
        {
            case MotionState.Idle:
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", false);
                break;
            case MotionState.Walking:
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);

                //walkSpeed = 2f;
                break;
            case MotionState.Running:
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", true);
                //walkSpeed = 6f;
                break;
        }
    }


    void ArrowsKeyPressed()
    {
        


        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrowsKeyPressed = true;
        }


        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            arrowsKeyPressed = true;            
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            arrowsKeyPressed = false;
        }
    }
    private void playerMoves()
    {

        

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction.Normalize();

        direction.y -= _gravity;

        //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high

        //controller.Move(direction * Time.deltaTime * walkSpeed); //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


        //walk
        if (arrowsKeyPressed && !Input.GetKey(KeyCode.RightShift))
        {

            
           
         transitState(MotionState.Walking);
         controller.Move(direction * Time.deltaTime * walkSpeed); //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high
   
        }
        else if (arrowsKeyPressed&& Input.GetKey(KeyCode.RightShift))
        {

            transitState(MotionState.Running);
            controller.Move(direction * Time.deltaTime * runSpeed); //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high

        }
        

        else
        {
            transitState(MotionState.Idle);
        }

    }

   

    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        

    }

    public void MoveTo(Vector3 targetPoint) //simply move to a point
    {
        Vector3 moveVector = targetPoint - Player.transform.position;
        controller.Move(moveVector);

    }


    








}
