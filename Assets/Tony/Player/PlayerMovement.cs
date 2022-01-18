using System;
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
    public Animator animator; //for later animation use
                               // Start is called before the first frame update

    public bool arrowsKeyPressed; //if any of the arrows keys are pressed
    private bool OnGround;

    public enum MotionState { 
        Idle,
        Walking,
        Running,
        Sitting
    }

   

    public MotionState mState = MotionState.Idle;
    private float lastUnpressed;
    private float pressSpan = 1;
    private bool hold;

    private void Awake(){
        Player = this;

    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ArrowsKeyPressed();

        playerMoves();
        PlayerData.Instance.Update();
        OnGround = transform.Find("OnGroundCheck").GetComponent<GroundCheck>().onGround;
    }


    public void transitState(MotionState state) {
        if (mState == state)
            return;

        mState = state;
        //Debug.Log($"State transite to {mState}");
        switch (state)
        {
            case MotionState.Idle:
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
                animator.SetBool("isSitting", false);
                break;
            case MotionState.Walking:
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                animator.SetBool("isSitting", false);
                //walkSpeed = 2f;
                break;
            case MotionState.Running:
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
                animator.SetBool("isSitting", false);
                //walkSpeed = 6f;
                break;
            case MotionState.Sitting:
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
                animator.SetBool("isSitting", true);
                break;
        }
    }


    void ArrowsKeyPressed()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            arrowsKeyPressed = true;            
        else
            arrowsKeyPressed = false;
    }
    private void playerMoves()
    {

        

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction.Normalize();
        
        //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high

        //controller.Move(direction * Time.deltaTime * walkSpeed); //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high
        if (direction.magnitude > 0.05f)
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
        else if (arrowsKeyPressed && Input.GetKey(KeyCode.RightShift))
        {
            transitState(MotionState.Running);
            controller.Move(direction * Time.deltaTime * runSpeed); //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high
        }       
        else if (horizontalInput == 0 && verticalInput == 0)
        {
            transitState(MotionState.Idle);
        }        

        if (!OnGround)
        {
            //Debug.Log("Not Ground");
            direction.y += _gravity * Time.deltaTime * 100;           
            controller.Move(direction * Time.deltaTime);
        }
        else
        {
            direction.y = 0;
            controller.Move(direction * Time.deltaTime);
        }
    }

    public void MoveTo(Vector3 targetPoint) //simply move to a point
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = targetPoint;
        FindObjectOfType<GroundCheck>().onGround = false;
        GetComponent<CharacterController>().enabled = true;
    }
}
