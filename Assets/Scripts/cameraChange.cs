using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour {

    public GameObject[] cars; // Add items to array through the inspector
    GameObject current;
    int carsIndex;
    void Start(){
        carsIndex = 0;
        current = cars[0];
    }

    void Update () {
        if(Input.GetKeyDown(KeyCode.C)){
            carsIndex++;
            // When at the end of the array
            if(carsIndex == cars.Length){
                carsIndex = 0;
            }

            // Movement enable, disable
            current.GetComponent<CraftMovement>().enabled = false;
            cars[carsIndex].GetComponent<CraftMovement>().enabled = true;

            current = cars[carsIndex];
        }
    }
}
