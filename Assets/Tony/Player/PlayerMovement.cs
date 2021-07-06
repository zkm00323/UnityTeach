using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _gravity = 9.81f;

    private CharacterController controller;
    private Animator animator = null; //for later animation use
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayerData.Instance.Update();
    }
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        direction.y -= _gravity;

        controller.Move(direction * Time.deltaTime * _moveSpeed); //multiple by Time.deltaTime so it moves once/second. In update it moves once every frame and frame/second can be very high
    }

    //can run if energy is >30


}
