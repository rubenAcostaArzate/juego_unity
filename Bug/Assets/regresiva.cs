using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class regresiva : MonoBehaviour
{
    public TMP_Text texto;

    public float cuenta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     cuenta-=Time.deltaTime;
     texto.text=""+cuenta;
    }
}
