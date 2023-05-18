using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject player; // The target player object
    public float smoothSpeed = 0.125f; // The smoothness of the camera movement (smaller number is slower)

    private Vector3 offset; // The initial distance between the player and the camera

    void Start()
    {
        // Calculate and store the initial offset value
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Create a new position based on the player's position and the initial offset
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset.z);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
