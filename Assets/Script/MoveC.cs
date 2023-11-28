using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveC : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the speed of movement
    public float destroyThreshold = 0.1f; // Adjust this threshold based on the size of your objects

    private bool canBeDestroyed = false; // Flag to allow destruction only when true

    void Update()
    {
        // Move the object in the negative Z-direction
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Check if the down arrow key is pressed and a beat can be destroyed
        if (Input.GetKey(KeyCode.DownArrow) && canBeDestroyed)
        {
            // Get the LaneController component from the scene
            LaneController laneController = FindObjectOfType<LaneController>();

            // Check if a LaneController is found
            if (laneController != null)
            {
                // Notify the LaneController that a beat is destroyed
                laneController.OnBeatDestroyed();

                // Destroy the beat
                Destroy(gameObject);

                // Set the flag to prevent multiple destructions in a single frame
                canBeDestroyed = false;
            }
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
