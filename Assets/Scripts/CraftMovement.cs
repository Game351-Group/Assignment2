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
    public float hoverVariance = 0.2f; // Amount of vertical hover movement
    public float tiltVariance = 2f; // Amount of tilt while hovering
    public float hoverSpeed = 2f; // Speed of hover oscillation

    private Terrain terrain;
    private float originalY;
    private float timeOffset;

    void Start()
    {
        // Assign the active terrain to the terrain variable
        terrain = Terrain.activeTerrain;
        originalY = transform.position.y;
        timeOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Adjust hovercraft position and rotation based on terrain
        AdjustHeightAndTilt();

        // Movement - forward and backward
        if (Input.GetButton("Vertical"))
        {
            Vector3 vec = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
            transform.Translate(vec * speed * Time.deltaTime);
        }

        // Turning the hovercraft left and right
        if (Input.GetButton("Horizontal"))
        {
            Vector3 vec = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0);
            transform.Rotate(vec, turnSpeed * Time.deltaTime);
        }

        // Camera follow logic
        if (followCamera != null)
        {
            Vector3 cameraPosition = transform.position - transform.forward * cameraDistanceBack + Vector3.up * cameraHeight;
            followCamera.transform.position = cameraPosition;
            followCamera.transform.LookAt(transform.position);
        }

        HoverEffect();
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

    void HoverEffect()
    {
        if (!Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
        {
            // Apply vertical hover effect
            float hoverY = Mathf.Sin((Time.time + timeOffset) * hoverSpeed) * hoverVariance;
            transform.position = new Vector3(transform.position.x, transform.position.y + hoverY, transform.position.z);

            // Apply tilt hover effect
            float tiltZ = Mathf.Sin((Time.time + timeOffset) * hoverSpeed) * tiltVariance;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, tiltZ);
        }
    }
}
