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
    public static int targetsHit = 1, targetsMissed = 1, accuracy;

    public TextMeshProUGUI TargetsHitLbl, TargetsMissLbl;
    
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

            // Update labels
            TargetsHitLbl.text = "Hit: " + (targetsHit - 1);
            TargetsMissLbl.text = "Miss: "+ (targetsMissed - 1);

            int sum = targetsHit + targetsMissed;
            // Data to be exported into csv function
            accuracy = targetsHit * 100 / sum;
        }
        else
        {   
            isStartSpawn = false;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Press 1 to start the task
                TargetsHitLbl.text = "Hit: 0";
                TargetsMissLbl.text = "Miss: 0";
                isTaskStart = true;
            }

        }
    }

    public void SpawnTargets()
    {
        Instantiate(targetPrefab, TargetBounds.Instance.GetRandomPosition(), Quaternion.identity);
    }
}
