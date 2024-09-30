using UnityEngine;
using UnityEngine.UI; 

public class WalkToPoint : MonoBehaviour
{
    public Transform playerTransform;    
    public Transform targetPoint;        
    public float distanceThreshold = 2f; 

    public GameObject instructionPanel;  
    public Text instructionText; 

    private bool gameStarted = false;    
    public Vector3 worldStartPosition = new Vector3(0, 0, 0);

    private CharacterController characterController; 

    public GameObject nextTaskCanvas; 

    void Start()
    {
        instructionText.text = "Please walk to the cylinder!";
        instructionPanel.SetActive(true);
        nextTaskCanvas.SetActive(false);
        characterController = playerTransform.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!gameStarted)
        {
            float distanceToTarget = Vector3.Distance(playerTransform.position, targetPoint.position);
            Debug.Log("Distance to target: " + distanceToTarget);

            if (distanceToTarget < distanceThreshold)
            {
                OnPlayerReachedTarget();
            }
        }
    }

    void OnPlayerReachedTarget()
    {
        instructionPanel.SetActive(false);

        characterController.enabled = false;

        playerTransform.position = worldStartPosition;

        characterController.enabled = true;

        targetPoint.gameObject.SetActive(false);

        StartGame();
    }

     void StartGame()
    {
        gameStarted = true;

        nextTaskCanvas.SetActive(true); 
    }
}
