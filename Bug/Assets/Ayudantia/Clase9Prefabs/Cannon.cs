using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject prefabBala;
    
    public Transform spawnBala;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Instantiate(prefabBala, spawnBala.position, Quaternion.identity);
        }
    }
}
