using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tracker : MonoBehaviour
{
    public GameObject Monster;
    public TextMeshPro monsterDistText;

    // Starting position (will be set to TrackerObject's position)
    private Vector3 startPosition;

    // Reference to TrackerObject GameObject
    public GameObject trackerObject;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure TrackerObject and Monster are assigned in the Inspector
        if (trackerObject == null)
        {
            Debug.LogError("TrackerObject is not assigned in the Inspector!");
            return;
        }

        if (Monster == null)
        {
            Debug.LogError("Monster is not assigned in the Inspector!");
            return;
        }

        // Set startPosition to TrackerObject's position
        startPosition = trackerObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Monster is not null
        if (Monster != null)
        {
            // Get the current position of the Monster
            Vector3 monsterPosition = Monster.transform.position;
            // Calculate the distance from the start position to the Monster's position
            float distance = CalculateDistance(startPosition, monsterPosition);

            // Output the distance to the console with the unique name
            Debug.Log($"Distance from TrackerObject to {Monster.name} = {distance:F2}");

            // Display the distance using TextMeshPro
            if (monsterDistText != null)
            {
                monsterDistText.text = $"Distance to {Monster.name}: {distance:F2}";
            }
        }
    }

    float CalculateDistance(Vector3 point1, Vector3 point2)
    {
        // Calculate the Euclidean distance between two points in 3D space
        float distance = Vector3.Distance(point1, point2);
        return distance;
    }
}