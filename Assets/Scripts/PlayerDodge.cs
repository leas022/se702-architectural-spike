using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge: MonoBehaviour
{
    public float forwardSpeed = 10f;  // Speed at which the player moves forward
    public float laneSwitchSpeed = 10f;  // Speed at which the player switches lanes
    public int currentLane = 2;  // Start in the middle lane (0 = leftmost, 4 = rightmost)
    private float[] lanes = new float[] { -10f, -5f, 0f, 5f, 10f };  // X positions for each lane

    void Update()
    {
        // Handle constant forward movement along Z-axis
        MoveForward();

        // Handle lane switching with K and L
        HandleLaneSwitching();
    }

    void MoveForward()
    {
        // Move the character forward along the Z-axis constantly
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void HandleLaneSwitching()
    {
        // Move left if K is pressed and not in the leftmost lane
        if (Input.GetKeyDown(KeyCode.K) && currentLane > 0)
        {
            currentLane--;  // Move one lane to the left
        }
        // Move right if L is pressed and not in the rightmost lane
        else if (Input.GetKeyDown(KeyCode.L) && currentLane < lanes.Length - 1)
        {
            currentLane++;  // Move one lane to the right
        }

        // Smoothly move the player to the target lane's X position
        Vector3 targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneSwitchSpeed);
    }
}
