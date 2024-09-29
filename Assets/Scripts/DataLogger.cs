using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLogger : MonoBehaviour
{
    private string filePath;

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

    void CreateCSV()
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

    void LogValue(double value)
    {
        // The current scene
        Scene scene = SceneManager.GetActiveScene();

        // Log the reaction time to the CSV file
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + scene.name + "," + value);
            writer.Flush();
            writer.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Change this once we have a reaction time implementation
        // Detect if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Log a reaction time value to the CSV file
            LogValue(0.5);
        }
    }
}
