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

    private Vector3 lastPosition;
    private bool playerMoving = false;

    public GameObject character;

    private Coroutine spawningCoroutine; 

    public void Start()
    {
        isTaskStart = false;
        isStartSpawn = false;
        instance = this;
        lastPosition = character.transform.position; 
        Debug.Log("AimTask started. Waiting for input to begin.");
    }

    public void Update()
    {
        if (isTaskStart)
        {
            if (lastPosition != character.transform.position)
            {
                playerMoving = true;  
            }
            else
            {
                playerMoving = false;  
            }
            lastPosition = character.transform.position; 

            if (!isStartSpawn)
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
                isTaskStart = true;
                instructionCanvas.SetActive(false);
                gameUICanvas.SetActive(true);
            }
        }
    }

    IEnumerator WaitAndSpawn()
    {
        float waitTime = Random.Range(1f, 3f);

        while (!playerMoving)
        {
            yield return null; 


            lastPosition = character.transform.position; 
        }

        yield return new WaitForSeconds(waitTime);

        targetsShown++;
        Debug.Log("Spawning target " + targetsShown + " at position " + TargetBounds.Instance.GetRandomPosition());
        Instantiate(targetPrefab, TargetBounds.Instance.GetRandomPosition(), Quaternion.identity);
        DataLogger.Instance.StartTiming();
    }


    public void SpawnTargets()
    {
        if (targetsShown >= maxTargets)
        {
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
