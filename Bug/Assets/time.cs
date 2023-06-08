using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class time : MonoBehaviour
{

    public int tiempo;

    public GameObject mario;

    public TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempo>0){
            tiempo-=(int)Time.deltaTime;
            texto.text=""+tiempo;
        }

        if(tiempo<=0){
          mario.GetComponent<MovForceAnim>().vida=0;
          Destroy(mario);
        }
    }
}
