using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AimTask : MonoBehaviour
{
    [SerializeField] Camera cam;

    public GameObject targetPrefab;
    public static AimTask instance;
    public static bool isTaskStart;
    public static bool isStartSpawn;
    public static int targetsShown = 0;
    public static int maxTargets = 10;

    public GameObject instructionCanvas;

    public GameObject gameUICanvas;

    public void Start()
    {
        isTaskStart = false;
        isStartSpawn = false;
        instance = this;

    }

    public void Update()
    {
        if (isTaskStart == true)
        {
            // If game has started  & starting point is false
            if (isStartSpawn != true)
            {
                SpawnTargets();
                isStartSpawn = true;
            }
        }
        else
        {
            isStartSpawn = false;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Press 1 to start the task
                isTaskStart = true;
                instructionCanvas.SetActive(false);
                gameUICanvas.SetActive(true);
            }

        }
    }

    IEnumerator WaitAndSpawn()
    {
        // Wait a random period of time from 1s to 3s
        float waitTime = Random.Range(1f, 3f);
        Debug.Log("Waiting for " + waitTime + " seconds");

        yield return new WaitForSeconds(waitTime);

        // Spawn the target
        targetsShown++;
        Debug.Log("Spawning target " + targetsShown);
        Instantiate(targetPrefab, TargetBounds.Instance.GetRandomPosition(), Quaternion.identity);
        DataLogger.Instance.StartTiming();
    }

    public void SpawnTargets()
    {
        Debug.Log("Spawning targets");
        // Stop the game once we've shown all the targets
        if (targetsShown >= maxTargets)
        {
            // End the task and reset the game state
            isTaskStart = false;
            isStartSpawn = false;
            targetsShown = 0;
            instructionCanvas.SetActive(true);
            gameUICanvas.SetActive(false);
            return;
        }

        StartCoroutine(WaitAndSpawn());
    }

}