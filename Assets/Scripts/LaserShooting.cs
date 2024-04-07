using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooting : MonoBehaviour
{
    public GameObject laserObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile;

            Vector4 position = transform.position;
            Quaternion rotation = transform.rotation;

            projectile = Instantiate(laserObject, position, rotation) as GameObject;
        }
    }
}
