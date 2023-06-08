using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPosition : MonoBehaviour {
    private void Start() {
        
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("Hola Mundo");
        }
    }
}
