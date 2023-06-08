using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSpeed : MonoBehaviour {

    public float minSpeed, maxSpeed;

    public void SetMarioSpeed(Slider slider) {
        GetComponent<MovForceAnim>().fuerzaHorizontal = 
            Mathf.Lerp(minSpeed, maxSpeed, slider.value);
    }
}
