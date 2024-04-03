using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraChange : MonoBehaviour {

    public GameObject[] cars;
    GameObject current;
    int carsIndex;
    void Start(){
        carsIndex = 0;
        current = cars[0];
    }
    void Update () {
        if(Input.GetKeyDown(KeyCode.C)){
            carsIndex++;
            if(carsIndex == cars.Length){
                carsIndex = 0;
            }
            current.GetComponent<Movement>().enabled = false;
            cars[carsIndex].GetComponent<Movement>().enabled = true;
            GameObject.Find("camera").GetComponent<CinemachineVirtualCamera>().Follow = cars[carsIndex].transform;
            GameObject.Find("camera").GetComponent<CinemachineVirtualCamera>().LookAt = cars[carsIndex].transform;
            current = cars[carsIndex];
        }
    }
}
