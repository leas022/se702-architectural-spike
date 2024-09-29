using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerLbl;
    public float timer;

    private void DisplayTime(float displayTime)
    {
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        timerLbl.text = $"{minutes}:{seconds}";
    }

    void Start()
    {
        timer = 20f;
    }

    // Update is called once per frame
    void Update() 
    {
        if (AimTask.isTaskStart == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                DisplayTime(timer);
            }
            else
            {   
                // Set to initial state
                AimTask.isTaskStart = false;
                AimTask.isStartSpawn = false;
                AimTask.targetsHit = 1;
                AimTask.targetsMissed = 1;
                timerLbl.text = "0:00";
                timer = 20f;
            }
        } 
    }
}
