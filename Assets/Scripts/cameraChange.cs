using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour {

    public GameObject[] cars; // Add items to array through the inspector
    GameObject current;
    GameObject laser;
    int carsIndex;
    void Start(){
        carsIndex = 0;
        current = cars[0];
        laser = GameObject.Find("LaserLauncher");
    }

    void Update () {
        if(Input.GetKeyDown(KeyCode.C)){
            if(carsIndex == 0){
                laser.GetComponent<LaserShooting>().enabled = false;
            }
            carsIndex++;
            // When at the end of the array
            if(carsIndex == cars.Length){
                carsIndex = 0;
                laser.GetComponent<LaserShooting>().enabled = true;
            }

            // Movement enable, disable
            current.GetComponent<CraftMovement>().enabled = false;
            cars[carsIndex].GetComponent<CraftMovement>().enabled = true;

            current = cars[carsIndex];
        }
    }
}