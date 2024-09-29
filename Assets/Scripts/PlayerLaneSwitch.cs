using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaneSwitch : MonoBehaviour
{
    public float forwardSpeed = 12f; 
    public float laneSwitchSpeed = 10f; 
    public int currentLane = 2; 
    private float[] lanes = new float[] { -6f, -3f, 0f, 3f, 6f }; 
    private CharacterController characterController;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();

        characterController.height = 2f;  
        characterController.center = new Vector3(0, 1f, 0); 
    }

    void Update()
    {
        MoveForward();

        HandleLaneSwitching();
    }

    void MoveForward()
    {
        Vector3 forwardMovement = transform.forward * forwardSpeed * Time.deltaTime;
        characterController.Move(forwardMovement);

        // animator.SetFloat("Speed", forwardSpeed);
        animator.SetFloat("Speed", 2f); 
    }

    void HandleLaneSwitching()
    {
        if (Input.GetKeyDown(KeyCode.K) && currentLane > 0)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.L) && currentLane < lanes.Length - 1)
        {
            currentLane++; 
        }

        Vector3 targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneSwitchSpeed);
        characterController.Move(newPosition - transform.position); 
    }
}
