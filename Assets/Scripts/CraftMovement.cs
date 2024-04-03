using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the hovercraft
    public float turnSpeed = 100.0f; // Adjust the turning speed
    public Camera followCamera; // Assign your follow camera in the inspector
    public float cameraDistanceBack = 10.0f; // Distance behind the hovercraft for the camera
    public float cameraHeight = 5.0f; // Height of the camera above the hovercraft
    public float hoverHeight = 5.0f; // Desired hover height above the ground

    private Terrain terrain;

    void Start()
    {
        // Assign the active terrain to the terrain variable
        terrain = Terrain.activeTerrain;
    }

    void Update()
    {
        // Adjust hovercraft position and rotation based on terrain
        AdjustHeightAndTilt();

        // Movement - forward and backward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // Turning the hovercraft left and right
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Camera follow logic
        if (followCamera != null)
        {
            Vector3 cameraPosition = transform.position - transform.forward * cameraDistanceBack + Vector3.up * cameraHeight;
            followCamera.transform.position = cameraPosition;
            followCamera.transform.LookAt(transform.position);
        }
    }

    void AdjustHeightAndTilt()
    {
        // Cast a ray downwards from the hovercraft's position to get the terrain height and normal
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            float currentHeight = hit.point.y;
            Vector3 groundNormal = hit.normal;

            // Adjust hovercraft height
            Vector3 desiredPosition = new Vector3(transform.position.x, currentHeight + hoverHeight, transform.position.z);
            transform.position = desiredPosition;

            // Tilt hovercraft to align with the terrain's normal
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5);
        }
    }
}
