using UnityEngine;

public class CylinderController : MonoBehaviour
{
    public Transform player; // Assign the player's position
    public float speed = 5f; // Speed of the cylinder
    public int repetitions = 10; // Number of times the cylinder will move
    public float xRange = 4f; // Range for random X position (corridor width)
    public float zStartPosition = 40f; // Starting Z position of the cylinder (far end of the corridor)
    public float yPosition = 1f; // Y position to keep constant

    private int currentRepetition = 0;
    private bool moveCylinder = false;

    void Update()
    {
        // Detect if the "P" key is pressed to start the cylinder movement
        if (Input.GetKeyDown(KeyCode.P) && !moveCylinder)
        {
            StartMovement();
        }

        // Move the cylinder down the corridor toward the player
        if (moveCylinder && currentRepetition < repetitions)
        {
            transform.position += Vector3.back * speed * Time.deltaTime; // Move cylinder on Z-axis

            // If the cylinder passes the player (adjust this condition as needed)
            if (transform.position.z < player.position.z)
            {
                ResetCylinderPosition();
                currentRepetition++;
            }
        }
    }

    public void StartMovement()
    {
        currentRepetition = 0; // Reset the repetitions
        moveCylinder = true; // Start the movement
    }

    private void ResetCylinderPosition()
    {
        // Generate a random X position within the corridor's width
        float randomX = Random.Range(-xRange, xRange);

        // Reset the cylinder to the starting Z position (10 units away) with a new random X position
        transform.position = new Vector3(randomX, yPosition, zStartPosition);
    }
}
