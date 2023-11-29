using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveC : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the speed of movement
    public float destroyThreshold = 0.1f; // Adjust this threshold based on the size of your objects

    private bool canBeDestroyed = false; // Flag to allow destruction only when true
    private bool sKeyPressed = false; // Flag to track whether the "S" key is pressed
    private Score scoreScript; // Reference to the Score script

    void Start()
    {
        // Get the Score script component from the scene
        scoreScript = FindObjectOfType<Score>();
    }

    void Update()
    {
        // Move the object in the negative Z-direction
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Check if the S key is pressed and a beat can be destroyed
        if (Input.GetKeyDown(KeyCode.S) && canBeDestroyed && !sKeyPressed)
        {
            sKeyPressed = true;

            // Get the LaneController component from the scene
            LaneController laneController = FindObjectOfType<LaneController>();

            // Check if a LaneController is found
            if (laneController != null)
            {
                // Notify the LaneController that a beat is destroyed
                laneController.OnBeatDestroyed();

                // Increment the score by 10 using the Score script
                if (scoreScript != null)
                {
                    scoreScript.IncreaseScore(10);

                    // Increment the beatsDestroyed by 1 using the Score script
                    scoreScript.IncrementBeatsDestroyed(1);
                }

                // Destroy the beat
                Destroy(gameObject);
            }
        }

        // Check if the S key is released
        if (Input.GetKeyUp(KeyCode.S))
        {
            sKeyPressed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the beat collides with the white platform
        if (other.CompareTag("WhitePlatform"))
        {
            // Set the flag to allow destruction
            canBeDestroyed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the beat exits the white platform
        if (other.CompareTag("WhitePlatform"))
        {
            // Set the flag to prevent destruction
            canBeDestroyed = false;
        }
    }
}