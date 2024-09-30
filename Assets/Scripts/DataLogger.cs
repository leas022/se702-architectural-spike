using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLogger : MonoBehaviour
{
    public static DataLogger Instance { get; private set; }
    private string filePath;
    private double startTime;

    // Use a singleton pattern
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Persist across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine("Logging", "reaction_time.csv");
        Debug.Log("Data is being logged to: " + filePath);

        // Check if the CSV file exists
        if (!File.Exists(filePath))
        {
            CreateCSV();
        }
    }

    public void StartTiming()
    {
        // Start the timer
        startTime = Time.realtimeSinceStartup;
    }

    private void CreateCSV()
    {
        // Create a new CSV file
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            // Write the header
            writer.WriteLine("Date,Scene,Reaction Time");
            writer.Flush();
            writer.Close();
        }
    }


    public void WriteTime()
    {
        // End the timer
        double endTime = Time.realtimeSinceStartup;

        double reactionTime = endTime - startTime;

        // The current scene
        Scene scene = SceneManager.GetActiveScene();

        // Log the reaction time to the CSV file
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + scene.name + "," + reactionTime.ToString("F4", CultureInfo.InvariantCulture));
            writer.Flush();
            writer.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing needs to be done here
    }
}
