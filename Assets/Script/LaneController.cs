using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    public float laneMoveSpeed = 1f; // Speed at which the lane moves
    public float laneMoveDistance = 1f; // Distance to move the lane for each beat destroyed

    void Update()
    {
        // Move the lane in the negative Z-direction
        transform.Translate(Vector3.back * laneMoveSpeed * Time.deltaTime);
    }

    // Called when a beat is destroyed
    public void OnBeatDestroyed()
    {
        // Move the lane by the specified distance in the negative Z-direction
        transform.Translate(Vector3.back * laneMoveDistance);
    }
}
